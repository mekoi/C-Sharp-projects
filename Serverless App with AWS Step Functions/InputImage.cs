using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrisiMekoLab4
{
    [DynamoDBTable("Image")]
    public class InputImage
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty]
        public string BucketName { get; set; }

        [DynamoDBProperty]
        public string KeyName { get; set; }

        [DynamoDBProperty]
        public byte[] Metadata { get; set; }

        [DynamoDBProperty(AttributeName = "Labels")]
        public List<ImageLabel> Labels { get; set; }
    }
}
