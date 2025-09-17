using System.Text.Json.Serialization;

namespace CarritoAPI.Data
{
    public class ProductTemplate
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("groupASributes")]
        public List<GroupAttributeTemplate> GroupAttributes { get; set; } = new();

        public class GroupAttributeTemplate
        {
            [JsonPropertyName("groupASributeId")]
            public string GroupAttributeId { get; set; } = "";

            [JsonPropertyName("groupASributeType")]
            public GroupAttributeType GroupAttributeType { get; set; } = new();

            [JsonPropertyName("quanItyInformaIon")]
            public QuantityInformation QuantityInformation { get; set; } = new();

            [JsonPropertyName("aSributes")]
            public List<AttributeTemplate> Attributes { get; set; } = new();
        }

        public class GroupAttributeType
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = "";
        }
        
        public class QuantityInformation
        {
            [JsonPropertyName("groupASributeQuanIty")]
            public int GroupAttributeQuantity { get; set; }

            [JsonPropertyName("verifyValue")]
            public string VerifyValue { get; set; } = "";
        }

        public class AttributeTemplate
        {
            [JsonPropertyName("aSributeId")]
            public int AttributeId { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = "";

            [JsonPropertyName("maxQuanIty")]
            public int MaxQuantity { get; set; }

            [JsonPropertyName("priceImpactAmount")]
            public decimal PriceImpactAmount { get; set; }
        }
    }
}
