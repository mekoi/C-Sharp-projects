using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace _301072868_meko__lab2
{
    class DBOperations
    {
        AmazonDynamoDBClient client;
        BasicAWSCredentials credentials;
        string tableName1 = "Bookshelf";
        string tableName2 = "Snapshot";

        public DBOperations()
        {

            credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
            client = new AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);
        }

        public void CreateTable1() 
        {           
            CreateTableRequest request = new CreateTableRequest
            {
                TableName = tableName1,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName="UserEmail",
                        AttributeType="S"
                    },
                    new AttributeDefinition
                    {
                        AttributeName="ISBN",
                        AttributeType="S"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName="UserEmail",
                        KeyType="HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName="ISBN",
                        KeyType="RANGE"
                    }
                },
                BillingMode = BillingMode.PROVISIONED,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 2,
                    WriteCapacityUnits = 1
                }
            };
            var response = client.CreateTable(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(tableName1 + " DynamoDB table created successfully.", "Table Creation Result");
            }
        }

        public void CreateTable2()
        {
            CreateTableRequest request = new CreateTableRequest
            {
                TableName = tableName2,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName="UserEmail",
                        AttributeType="S"
                    },             
                    new AttributeDefinition
                    {
                        AttributeName="ISBN",
                        AttributeType="S"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName="UserEmail",
                        KeyType="HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName="ISBN",
                        KeyType="RANGE"
                    }
                },
                BillingMode = BillingMode.PROVISIONED,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 2,
                    WriteCapacityUnits = 1
                }
            };
            var response = client.CreateTable(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(tableName2 + " DynamoDB table created successfully.", "Table Creation Result");
            }
        }

        public void InsertItem2Bookshelf(string userEmail, string iSBN, string title, string author1, string author2, string author3, string publisher, string edition, string copyrightYear)
        {
            PutItemRequest request = new PutItemRequest
            {
                TableName = tableName1,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "UserEmail", new AttributeValue{S=userEmail} },
                    { "ISBN", new AttributeValue{S=iSBN} },
                    { "Title", new AttributeValue{S=title} },
                    { "Author1", new AttributeValue{S=author1} },
                    { "Author2", new AttributeValue{S=author2} },
                    { "Author3", new AttributeValue{S=author3} },
                    { "Publisher", new AttributeValue{S=publisher} },
                    { "Edition", new AttributeValue{N=edition} },
                    { "CopyrightYear", new AttributeValue{N=copyrightYear} }
                }
            };

            var response = client.PutItem(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Item inserted successfully into " + tableName1 + " table.", "Insert Result");
            }
        }

        public void InsertSnapshot(string userEmail, string iSBN, string title, string pageNo)
        {
            //Table Snapshot has UserEmail as Partition Key and ISBN as Sort Key, so only a combination of UserEmail-ISBN can exist in it.
            //Thus, before inserting we query if any combination of these two attributes exists. If not, we insert, otherwise we update with latest page no and datestamp.
            
            GetItemRequest requestGet = new GetItemRequest
            {
                TableName = tableName2,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserEmail", new AttributeValue{S=userEmail} },
                    { "ISBN", new AttributeValue { S = iSBN } }
                }
            };

            var responseGet = client.GetItem(requestGet);

            if (responseGet.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                if (responseGet.Item.Count == 0)      ///If no snapshot exist in the table for given UserEmail and ISBN, we insert new item.
                {
                    PutItemRequest requestPut = new PutItemRequest
                    {
                        TableName = tableName2,
                        Item = new Dictionary<string, AttributeValue>
                        {
                            { "UserEmail", new AttributeValue{S=userEmail} },
                            { "ISBN", new AttributeValue{S=iSBN} },
                            { "Title", new AttributeValue{S=title} },
                            { "PageNo", new AttributeValue{N=pageNo} },
                            { "TimeStamp", new AttributeValue{S=System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} }
                        }
                    };

                    var responsePut = client.PutItem(requestPut);

                    if (responsePut.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Item inserted successfully into " + tableName2 + " table.", "Insert Result");
                    }
                }
                else
                {
                    ///The snapshot exists in the table the given UserEmail and ISBN, so we update item.
                    Table snapshotTable = Table.LoadTable(client, tableName2);
                    var snapshotItem = new Document();
                    snapshotItem["UserEmail"] = userEmail;
                    snapshotItem["ISBN"] = iSBN;
                    snapshotItem["PageNo"] = pageNo;
                    snapshotItem["TimeStamp"] = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                    // Creating a condition expression.
                    Amazon.DynamoDBv2.DocumentModel.Expression expr = new Amazon.DynamoDBv2.DocumentModel.Expression();
                    expr.ExpressionStatement = "UserEmail = :valUserEmail and ISBN = :valIsbn";
                    expr.ExpressionAttributeValues[":valUserEmail"] = userEmail;
                    expr.ExpressionAttributeValues[":valIsbn"] = iSBN;

                    Document updatedSnapshot = snapshotTable.UpdateItem(snapshotItem);

                    MessageBox.Show("Snapshot updated successfully into " + tableName2 + " table.", "Update Result");

                }
            }       
        }

        public string ShowBookshelf(string userEmail, string iSBN)
        {
            string outputString = "Table " + tableName1 + " items: \n\n";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName1,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserEmail", new AttributeValue{S=userEmail} },
                    { "ISBN", new AttributeValue { S = iSBN } }
                }
            };

            var response = client.GetItem(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Item.Count > 0)
                {
                    foreach (var item in response.Item)
                        outputString += $"Key: {item.Key},  Value: {item.Value.S}{item.Value.N}\n";
                }
            }
            return outputString;
        }

        public string ShowSnapshot(string userEmail, string iSBN)
        {
            string outputString = "Snapshot of user " + userEmail + ": \n\n";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName2,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserEmail", new AttributeValue{S=userEmail} },
                    { "ISBN", new AttributeValue { S = iSBN } }
                }
            };

            var response = client.GetItem(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                if (response.Item.Count == 0)
                {
                    outputString += $"The user {userEmail} hasn't started reading.\n";
                }
                else    
                {
                    foreach (var item in response.Item)
                        outputString += $"Key: {item.Key},  Value: {item.Value.S}{item.Value.N}\n";
                }
            }
            return outputString;

        }
    }
}
