
namespace ASF_Manager.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    class Exec_ComandResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
