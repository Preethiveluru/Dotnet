namespace ReadingJSON.Models
{
    public class Pincode
    {
        public class PostPin
        {
            public string Name { get; set; }
            public string Description { get; set; }
            //"BranchType": "Branch Post Office",
            public string BranchType { get; set; }
            //"DeliveryStatus": "Delivery",
            public string Circle { get; set; }

            //"Circle": "Karnataka",

            //"District": "Mysore",
            public string District { get; set; }
            public string Division { get; set; }

            //"Division": "Nanjangud",
            public string Region { get; set; }
            //"Region": "South Karnataka",
            //"Block": "Nanjangud",
            public string Block { get; set; }
            //"State": "Karnataka",
            public string State { get; set; }
            //"Country": "India",
            public string Country { get; set; }
            //"Pincode": "571118"
            public int PinCode { get; set; }
        }
    }
}
