using System;

/// <summary>
/// Constructor for Properties
/// Created by Nick Lemonrod
/// </summary>

namespace Housing_Project {
    public class Properties {
        string identifier;
        string county;
        string bedrooms;
        string address;
        string city;
        string picture;
        string phone;
        string email;
        string program;
        string name;
        string ownerId;

        public Properties(string Identifier, string County, string Bedrooms, string Address, string City, string Picture, string Phone, string Email, string Program, string Name, string OwnerId) {
            this.identifier = Identifier;
            this.county = County;
            this.bedrooms = Bedrooms;
            this.address = Address;
            this.city = City;
            this.picture = Picture;
            this.phone = Phone;
            this.email = Email;
            this.program = Program;
            this.name = Name;
            this.ownerId = OwnerId;
        }

        public string GetIdentifier() {
            return this.identifier;
        }

        public string GetCounty() {
            return this.county;
        }

        public string GetBedrooms() {
            return this.bedrooms;
        }

        public string GetAddress() {
            return this.address;
        }

        public string GetCity() {
            return this.city;
        }

        public string GetPicture() {
            return this.picture;
        }

        public string GetPhone() {
            return this.phone;
        }

        public string GetEmail() {
            return this.email;
        }

        public string GetProgram() {
            return this.program;
        }
        public string GetName() {
            return this.name;
        }

        public string GetOwnerId() {
            return this.ownerId;
        }
    }
}
