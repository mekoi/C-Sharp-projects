using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IrisiMekoLab4
{
    public class StepFunctionTasks
    {
        IAmazonS3 S3Client { get; }
        IAmazonRekognition RekognitionClient { get; }
        IAmazonDynamoDB dynamoDBClient { get; }
        HashSet<string> SupportedImageTypes { get; } = new HashSet<string> { ".png", ".jpg", ".jpeg" };

        public StepFunctionTasks()
        {
            this.dynamoDBClient = new AmazonDynamoDBClient();
            this.S3Client = new AmazonS3Client();
            this.RekognitionClient = new AmazonRekognitionClient();
            new DynamoDBOperations(dynamoDBClient);
        }

        public async Task<State> ImageRecognitionSaveToDynamoDB(State state, ILambdaContext context)
        {
            if (!SupportedImageTypes.Contains(Path.GetExtension(state.key)) || state.key.Contains("grayscale"))
            {
                Console.WriteLine($"Object {state.bucketName}:{state.key} is not a supported image type");
                return null;
            }

            Console.WriteLine($"Looking for labels in image {state.bucketName}:{state.key}");
            var detectResponses = await this.RekognitionClient.DetectLabelsAsync(new DetectLabelsRequest
            {
                MinConfidence = state.MinConfidence,
                Image = new Image
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object
                    {
                        Bucket = state.bucketName,
                        Name = state.key
                    }
                }
            });

            var tags = new List<Amazon.DynamoDBv2.Model.Tag>();
            var labels = new List<ImageLabel>();
            foreach (var label in detectResponses.Labels)
            {
                if (tags.Count < 10)
                {
                    Console.WriteLine($"\tFound Label {label.Name} with confidence {label.Confidence}");
                    tags.Add(new Amazon.DynamoDBv2.Model.Tag { Key = label.Name, Value = label.Confidence.ToString() });
                    labels.Add(new ImageLabel { Key = label.Name, Value = label.Confidence.ToString() });
                }
                else
                {
                    Console.WriteLine($"\tSkipped label {label.Name} with confidence {label.Confidence} because the maximum number of tags has been reached");
                }
            }

            byte[] metadata;
            using (GetObjectResponse response = await this.S3Client.GetObjectAsync(
                state.bucketName,
                state.key))
            {
                using (Stream responseStream = response.ResponseStream)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        using (var memStream = new MemoryStream())
                        {
                            var buffer = new byte[512];
                            var bytesRead = default(int);

                            while ((bytesRead = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                                memStream.Write(buffer, 0, bytesRead);

                            metadata = memStream.ToArray();
                        }
                    }
                }
            }

            InputImage image = new InputImage();
            image.BucketName = state.bucketName;
            image.KeyName = state.key;
            image.Labels = labels;
            image.Metadata = metadata;

            image = new DynamoDBOperations(dynamoDBClient).Create(image).Result;

            Console.WriteLine($"\tSaved {image.KeyName} with confidence {image.Id}");

            return state;
        }

        public async Task<State> ThumbnailGeneration(State state, ILambdaContext context)
        {
            try
            {
                using (GetObjectResponse response = await S3Client.GetObjectAsync(

                    state.bucketName,

                    state.key))

                {

                    using (Stream responseStream = response.ResponseStream)

                    {

                        using (StreamReader reader = new StreamReader(responseStream))

                        {

                            using (var memstream = new MemoryStream())

                            {

                                var buffer = new byte[512];

                                var bytesRead = default(int);

                                while ((bytesRead = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)

                                    memstream.Write(buffer, 0, bytesRead);

                                var transformedImage = GreyscaleImagingOperations.GetConvertedImage(memstream.ToArray());

                                PutObjectRequest putRequest = new PutObjectRequest()

                                {

                                    BucketName = state.bucketName,

                                    Key = $"grayscale-{state.key}",



                                    ContentBody = transformedImage

                                };

                                await S3Client.PutObjectAsync(putRequest);

                            }

                        }

                    }

                }

                var responcelambda = await this.S3Client.GetObjectMetadataAsync(state.bucketName, state.key);

                return state;
            }

            catch (Exception e)

            {

                throw;

            }

        }
    }
}
