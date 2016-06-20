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
			//Look for existing name
			Name existingName = FindExistingName(client);
			if (existingName != null)
			{
				return existingName;
			}

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

		private Name FindExistingName(JustWareApiClient client)
		{
			string query = "Last = \"Thawne\" && First = \"Eobard\" && DriversLicenseNumber=\"[yourLastName]-12\"";
			List<Name> existingNames = client.FindNames(query, null);
			if (existingNames.Count > 0)
			{
				Console.WriteLine("Existing name found.");

				if (existingNames.Count > 1)
				{
					Console.WriteLine("Deleting name duplicates...");

					for (int i = 1; i < existingNames.Count; i++)
					{
						Name deleteName = existingNames[i];
						deleteName.Operation = OperationType.Delete;
						client.Submit(deleteName);
					}
				}

				return existingNames[0];
			}

			return null;
		}
		public Phone AddPhones(JustWareApiClient client, Name name)
		{
			Phone phone = new Phone();
			phone.Operation = OperationType.Insert;
			phone.TempID = "ID1";
			phone.TypeCode = "HP";
			phone.Number = "111-111-1111";
			phone.NameID = name.ID;

			List<Key> keys = client.Submit(phone);
			int phoneId = keys[0].NewID;
			Phone newPhone = client.GetPhone(phoneId);

			return newPhone;
		}

		public Phone AddPhones2(JustWareApiClient client, Name name)
		{
			name.Phones = new List<Phone>();

			Phone phone = new Phone();
			phone.Operation = OperationType.Insert;
			phone.TempID = "ID1";
			phone.TypeCode = "HP";
			phone.Number = "111-111-1111";
			name.Phones.Add(phone);

			List<Key> keys = client.Submit(name);
			Phone newPhone = new Phone();
			foreach (Key key in keys)
			{
				if (key.TypeName == "Phone")
				{
					newPhone = client.GetPhone(key.NewID);
				}
			}

			return newPhone;
		}

		public Email AddEmail(JustWareApiClient client, Name name)
		{
			Email email = new Email();
			email.Operation = OperationType.Insert;
			email.TypeCode = "BUS";
			email.Address = "someone@somewhere.com";
			email.NameID = name.ID;

			List<Key> keys = client.Submit(email);
			int emailId = keys[0].NewID;
			Email newEmail = client.GetEmail(emailId);

			return newEmail;
		}

		public Address AddAddresses(JustWareApiClient client, Name name)
		{
			Address address = new Address();
			address.Operation = OperationType.Insert;
			address.TypeCode = "HA";
			address.StateCode = "UT";
			address.City = "Logan";
			address.Zip = "84405";
			address.StreetAddress = "843 South 100 West";
			address.NameID = name.ID;

			List<Key> keys = client.Submit(address);
			int addressId = keys[0].NewID;
			Address newAddress = client.GetAddress(addressId);

			return newAddress;
		}

		public NameAttribute AddNameAttributes(JustWareApiClient client, Name name)
		{
			NameAttribute attribute = new NameAttribute();
			attribute.Operation = OperationType.Insert;
			attribute.TypeCode = "WARR";
			attribute.NameID = name.ID;

			List<Key> keys = client.Submit(attribute);
			int attributeId = keys[0].NewID;
			NameAttribute newAttribute = client.GetNameAttribute(attributeId);

			return newAttribute;
		}

		public NameEvent AddNameEvents(JustWareApiClient client, Name name)
		{
			NameEvent nameEvent = new NameEvent();
			nameEvent.Operation = OperationType.Insert;
			nameEvent.EventDate = DateTime.Now;
			nameEvent.EventEndDate = DateTime.Now.AddHours(2);
			nameEvent.TypeCode = "ARR";
			nameEvent.NameID = name.ID;
			nameEvent.Title = "My Name Event";
			name.Events.Add(nameEvent);

			List<Key> keys = client.Submit(nameEvent);
			int nameEventId = keys[0].NewID;
			NameEvent newNameEvent = client.GetNameEvent(nameEventId);

			return newNameEvent;
		}

		public NameNote AddNameNotes(JustWareApiClient client, Name name)
		{
			NameNote note = new NameNote();
			note.Operation = OperationType.Insert;
			note.DateTaken = DateTime.Now;
			note.Notes = "Some notes";
			note.TakenBy = name.ID;
			note.NameID = name.ID;

			List<Key> keys = client.Submit(note);
			int noteId = keys[0].NewID;
			NameNote newNote = client.GetNameNote(noteId);

			return newNote;
		}

		public NameTask AddNameTask(JustWareApiClient client, Name name)
		{
			NameTask task = new NameTask();
			task.Operation = OperationType.Insert;
			task.EventDate = DateTime.Now;
			task.EventEndDate = DateTime.Now.AddHours(1);
			task.TypeCode = "TASK";
			task.Title = "My Name Task";
			task.NameID = name.ID;

			List<Key> keys = client.Submit(task);
			int taskId = keys[0].NewID;
			NameTask newTask = client.GetNameTask(taskId, null);

			return newTask;
		}
	}
}
