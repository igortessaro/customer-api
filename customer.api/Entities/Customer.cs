using System;

namespace customer.api.Entities
{
    public sealed class Customer
    {
        public Customer(
            string firstName,
            string lastName,
            string phone,
            DateTime? lastPurchase,
            int genderId,
            int classificationId,
            int regionId,
            int stateId,
            int cityId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.LastPurchase = lastPurchase;
            this.GenderId = genderId;
            this.ClassificationId = classificationId;
            this.RegionId = regionId;
            this.StateId = stateId;
            this.CityId = cityId;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Phone { get; private set; }

        public DateTime? LastPurchase { get; private set; }

        public int GenderId { get; private set; }

        public int ClassificationId { get; private set; }

        public int RegionId { get; private set; }

        public int StateId { get; private set; }

        public int CityId { get; private set; }

        public void Update(string firstName, string lastName, string phone, DateTime? lastPurchase, int genderId, int classificationId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.LastPurchase = lastPurchase;
            this.GenderId = genderId;
            this.ClassificationId = classificationId;
        }

        public void UpdateRegion(int regionId, int stateId, int cityId)
        {
            this.RegionId = regionId;
            this.StateId = stateId;
            this.CityId = cityId;
        }
    }
}
