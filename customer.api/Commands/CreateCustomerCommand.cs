using customer.api.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace customer.api.Commands
{
    public sealed class CreateCustomerCommand
    {
        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength:11, MinimumLength = 11)]
        public string Phone { get; set; }

        public DateTime? LastPurchase { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int GenderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ClassificationId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int RegionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int StateId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CityId { get; set; }

        public Customer Build()
        {
            var result = new Customer(this.FirstName, this.LastName, this.Phone, this.LastPurchase, this.GenderId, this.ClassificationId, this.RegionId, this.StateId, this.CityId);

            return result;
        }
    }
}
