using InvitationBuilder.Models;

namespace UnitTests.Models
{
    internal class Address : IAddress
    {
        /// <inheritdoc />
        public string? Name { get; }

        /// <inheritdoc />
        public string? StreetNumberAndName { get; }

        /// <inheritdoc />
        public string? SuiteApt { get; }

        /// <inheritdoc />
        public string? City { get; }

        /// <inheritdoc />
        public string? Canton { get; }

        /// <inheritdoc />
        public string? State { get; }

        /// <inheritdoc />
        public string? Country { get; }

        /// <inheritdoc />
        public string? PostalCode { get; }

        /// <inheritdoc />
        public IGeoCode? Location { get; }

        /// <inheritdoc />
        public string? FullAddress { get; }

        public Address(string? name, string? streetNumberAndName, string? suiteApt, string? city, string? canton, string? state, string? country, string? postalCode, IGeoCode? location, string? fullAddress)
        {
            Name = name;
            StreetNumberAndName = streetNumberAndName;
            SuiteApt = suiteApt;
            City = city;
            Canton = canton;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Location = location;
            FullAddress = fullAddress;
        }
    }
}
