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
			Console.WriteLine("Creating new name...");

			//Create Object

			//Fill out required info

			//Fill out additional info

			//Submit

			//Get name from database

			return null;
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

			//Fill out information

			//Submit

			//Get object from database

			return null;
		}

		//Another way to insert an entity collection
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

			//Fill out info - Operation, TypeCode = "HA", StateCode = "UT", City, Zip, StreetAddress, NameID

			//Submit Email and set keys

			//Use keys to get new Address object from database

			//Return new Address
			return null;
		}

		public Email AddEmail(JustWareApiClient client, int nameId)
		{
			//Create Email object

			//Fill out info - Operation, TypeCode = "BUS", Address, NameID

			//Submit Email and set keys

			//Use keys to get new Email object from database

			//Return new Email
			return null;
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
