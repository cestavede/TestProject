using System;

namespace BusinessRegistryApi
{
    public class CompanyItem
    {
        public string CompanyName { get; set;  }

        // Ideally this should be Guid or similar (in order to simplify I will use int for now)
        public int CompanyId { get; set; }

        public string Address{ get; set; }

        public string ICO { get; set; }

    }
}