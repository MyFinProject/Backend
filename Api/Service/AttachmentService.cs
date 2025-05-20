using Api.Dto.Attachment;
using Api.Interfaces;
using Api.Models;
using IronBarCode;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Api.Service
{


    public class AttachmentService : IAttachmentService
    {
        public async Task<CheckModel?> ReadQr(AttachmentDto attachmentDto) 
        {
            string token = "33330.6pWcOBkcY8e3wvjYw";
            string apiUrl = "https://proverkacheka.com/api/v1/check/get";
            string attachmentUrl = attachmentDto.FilePath;

            using (HttpClient client = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(token), "token");
                formData.Add(new StringContent(attachmentUrl), "qrurl");

                HttpResponseMessage response = await client.PostAsync(apiUrl, formData);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if(jsonResponse == null)
                {
                    return null;
                }

                ReceiptData receipt = JsonSerializer.Deserialize<ReceiptData>(jsonResponse);
                

                CheckModel check = new CheckModel
                {
                    totalSum = receipt.data.json.totalSum,
                    operationType = receipt.data.json.operationType,
                    items = receipt.data.json.items,
                };

                return check;
            }
        }
    }
}
