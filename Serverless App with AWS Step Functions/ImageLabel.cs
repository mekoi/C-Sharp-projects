using Amazon.DynamoDBv2.DataModel;

namespace IrisiMekoLab4
{
    public class ImageLabel
    {
        [DynamoDBProperty]
        public string Key { get; set; }
        [DynamoDBProperty]
        public string Value { get; set; }
    }
}