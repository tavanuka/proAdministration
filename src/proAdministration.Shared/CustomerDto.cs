using System.Text.Json.Serialization;

namespace proAdministration.Shared;

public class CustomerDto
{
    [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("businessId")]
        public int BusinessId { get; set; }

        [JsonPropertyName("changed")]
        public DateTime Changed { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("company")]
        public string Company { get; set; } = string.Empty;

        [JsonPropertyName("confirmCompleteDate")]
        public DateTime ConfirmCompleteDate { get; set; }

        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }

        [JsonPropertyName("confirmRequestDate")]
        public DateTime ConfirmRequestDate { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("customerNumber")]
        public string CustomerNumber { get; set; } = string.Empty;

        [JsonPropertyName("dataTypeName")]
        public string DataTypeName { get; set; } = string.Empty;

        [JsonPropertyName("dataTypeTitle")]
        public string DataTypeTitle { get; set; } = string.Empty;

        [JsonPropertyName("deletable")]
        public bool Deletable { get; set; }

        [JsonPropertyName("editable")]
        public bool Editable { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("employee")]
        public bool Employee { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; } = string.Empty;

        [JsonPropertyName("internal")]
        public bool Internal { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [JsonPropertyName("merchantId")]
        public int MerchantId { get; set; }

        [JsonPropertyName("newsletter")]
        public bool Newsletter { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("preventChanges")]
        public bool PreventChanges { get; set; }

        [JsonPropertyName("salutationId")]
        public int SalutationId { get; set; }

        [JsonPropertyName("shared")]
        public bool Shared { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("streetAddition")]
        public string StreetAddition { get; set; } = string.Empty;

        [JsonPropertyName("syncKey")]
        public string SyncKey { get; set; } = string.Empty;

        [JsonPropertyName("syncTime")]
        public DateTime SyncTime { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("vatNumber")]
        public string VatNumber { get; set; } = string.Empty;

        [JsonPropertyName("zip")]
        public string Zip { get; set; } = string.Empty;
}