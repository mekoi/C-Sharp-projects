﻿using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrisiMekoLab4
{
    public class DynamoDBOperations
    {
        RegionEndpoint Region = RegionEndpoint.USEast1;
        IAmazonDynamoDB dynamoDBClient { get; }
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        String tableName = "Image";

        public DynamoDBOperations(IAmazonDynamoDB dynamoDBClient)
        {
            this.dynamoDBClient = dynamoDBClient;
            CreateTable();
        }

        public Task<InputImage> GetById(string Id)
        {
            DynamoDBContext Context = new DynamoDBContext(dynamoDBClient);
            var image = Context.LoadAsync<InputImage>(Id, default(System.Threading.CancellationToken));
            return image;
        }

        public async Task<InputImage> Create(InputImage image)
        {
            image.Id = (image.BucketName + image.KeyName);
            DynamoDBContext Context = new DynamoDBContext(dynamoDBClient);
            await Context.SaveAsync<InputImage>(image);
            return image;
        }

        public void CreateTable()
        {
            Task<ListTablesResponse> table = dynamoDBClient.ListTablesAsync();
            List<string> currentTables = table.Result.TableNames;
            bool tablesAdded = false;
            if (!currentTables.Contains(tableName))
            {
                dynamoDBClient.CreateTableAsync(new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 3, WriteCapacityUnits = 1 },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Id",
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = "Id", AttributeType = ScalarAttributeType.S}
                    },
                });
                tablesAdded = true;
            }

            if (tablesAdded)
            {
                bool allActive;
                do
                {
                    allActive = true;
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    TableStatus tableStatus = GetTableStatus(tableName);
                    if (!object.Equals(tableStatus, TableStatus.ACTIVE))
                        allActive = false;

                } while (!allActive);
            }
        }

        private TableStatus GetTableStatus(string tableName)
        {
            try
            {
                Task<DescribeTableResponse> tableResp = dynamoDBClient.DescribeTableAsync(new DescribeTableRequest { TableName = tableName });
                TableDescription table = tableResp.Result.Table;
                return (table == null) ? null : table.TableStatus;
            }
            catch (AmazonDynamoDBException db)
            {
                if (db.ErrorCode == "ResourceNotFoundException")
                    return string.Empty;
                throw;
            }
        }
    }
}
