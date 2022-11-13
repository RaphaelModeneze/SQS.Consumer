using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;


namespace SQS.Consumer
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("SQS.Consumer!");

            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = "https://sqs.sa-east-1.amazonaws.com/493103478301/My-Stack-StandardQueue-ErjE3wksE1AG"
            };

            while (true)
            {
                var response = await client.ReceiveMessageAsync(request);

                foreach (var mensagem in response.Messages)
                {
                    Console.WriteLine(mensagem.Body);
                    await client.DeleteMessageAsync("https://sqs.sa-east-1.amazonaws.com/493103478301/My-Stack-StandardQueue-ErjE3wksE1AG", mensagem.ReceiptHandle);
                }
            }
        }
    }
}