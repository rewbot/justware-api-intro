using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustWareApiIntro.JustWareApi;

namespace JustWareApiIntro
{
	public class NameInsertUtilities
	{
		public Name InsertName(JustWareApiClient client)
		{
			FindAndDeleteExistingNames(client);

			Console.WriteLine("Creating new name...");

			//Create Object
			Name name = new Name();

			//Fill out required info
			name.Operation = OperationType.Insert;
			name.Last = "Thawne";

			//Fill out additional info
			name.First = "Eobard";
			name.DateOfBirth = new DateTime(1942, 7, 13);
			name.Weight = 150;
			name.DriversLicenseNumber = "[yourLastName]-12";

			//Submit
			List<Key> keys = client.Submit(name);
			int nameId = keys[0].NewID;

			//Get name from database
			Name dbName = client.GetName(nameId, null);

			return dbName;
		}

		private void FindAndDeleteExistingNames(JustWareApiClient client)
		{
			string query = "Last = \"Thawne\" && First = \"Eobard\" && DriversLicenseNumber=\"[yourLastName]-12\"";
			List<Name> existingNames = client.FindNames(query, null);
			if (existingNames.Count > 0)
			{
				Console.WriteLine("Deleting name duplicates...");

				for (int i = 0; i < existingNames.Count; i++)
				{
					Name deleteName = existingNames[i];
					deleteName.Operation = OperationType.Delete;
					client.Submit(deleteName);
				}
			}
		}

		public Phone AddPhones(JustWareApiClient client, int nameId)
		{
			//Create phone object
			Phone phone = new Phone();

			//Fill out information
			phone.Operation = OperationType.Insert;
			phone.TypeCode = "HP";
			phone.Number = "111-111-1111";
			phone.NameID = nameId;

			//Submit
			List<Key> keys = client.Submit(phone);

			//Get object from database
			int phoneId = keys[0].NewID;
			Phone newPhone = client.GetPhone(phoneId);

			return newPhone;
		}

		public Phone AddPhones2(JustWareApiClient client, Name name)
		{
			//Initialize collection on Name entity
			name.Phones = new List<Phone>();

			//Create object and fill out inof
			Phone phone = new Phone();
			phone.Operation = OperationType.Insert;
			phone.TypeCode = "HP";
			phone.Number = "111-111-1111";
			name.Phones.Add(phone);

			//Submit the Name
			List<Key> keys = client.Submit(name);
			int phoneId = keys[0].NewID;

			return client.GetPhone(phoneId);
		}

		public Address AddAddresses(JustWareApiClient client, int nameId)
		{
			//Create Address object
			Address address = new Address();

			//Fill out info - Operation, TypeCode = "HA", StateCode = "UT", City, Zip, StreetAddress, NameID
			address.Operation = OperationType.Insert;
			address.TypeCode = "HA";
			address.StateCode = "UT";
			address.City = "Logan";
			address.Zip = "84405";
			address.StreetAddress = "843 South 100 West";
			address.NameID = nameId;

			//Submit Email and set keys
			List<Key> keys = client.Submit(address);

			//Use keys to get new Address object from database
			int addressId = keys[0].NewID;
			Address newAddress = client.GetAddress(addressId);

			//Return new Address
			return newAddress;
		}

		public Email AddEmail(JustWareApiClient client, int nameId)
		{
			//Create Email object
			Email email = new Email();

			//Fill out info - Operation, TypeCode = "BUS", Address, NameID
			email.Operation = OperationType.Insert;
			email.TypeCode = "BUS";
			email.Address = "someone@somewhere.com";
			email.NameID = nameId;

			//Submit Email and set keys
			List<Key> keys = client.Submit(email);

			//Use keys to get new Email object from database
			int emailId = keys[0].NewID;
			Email newEmail = client.GetEmail(emailId);

			//Return new Email
			return newEmail;
		}

		public NameEvent AddNameEvents(JustWareApiClient client, int nameId)
		{
			//Create NameEvent object

			//Fill out info - Operation, EventDate = DateTime.Now, EventEndDate = DateTime.Now.AddHours(2), TypeCode = "ARR", NameID

			//Submit NameEvent and set keys

			//Use keys to get new NameEvent object from database

			//Return new NameEvent
			return null;
		}

		public NameAttribute AddNameAttributes(JustWareApiClient client, int nameId)
		{
			//Create NameAttribute object

			//Fill out info - Operation, TypeCode = "WARR", NameID

			//Submit NameAttribute and set keys

			//Use keys to get new NameAttribute object from database

			//Return new NameAttribute
			return null;
		}

		public NameNote AddNameNotes(JustWareApiClient client, int nameId)
		{
			//Create NameNote object

			//Fill out info - Operation, DateTaken = DateTime.Now, Notes, TakenBy = client.GetCallerNameID(), NameId

			//Submit NameNote and set keys

			//Use keys to get new NameNote object from database

			//Return new NameNote
			return null;
		}

		public NameTask AddNameTask(JustWareApiClient client, int nameId)
		{
			//Create NameTask object

			//Fill out info - Operation, EventDate = DateTime.Now, EventEndDate = DateTime.Now.AddHours(1), TypeCode = "TASK", Title, NameID

			//Submit NameTask and set keys

			//Use keys to get new NameTask object from database

			//Return new NameTask
			return null;
		}
	}
}
