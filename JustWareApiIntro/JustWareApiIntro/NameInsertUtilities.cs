﻿using System;
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

			//Submit Name object and set keys
			List<Key> keys = client.Submit(name);

			//Use keys to get new Name object from database
			int nameId = keys[0].NewID;
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
			//Create Phone object
			Phone phone = new Phone();

			//Fill out information
			phone.Operation = OperationType.Insert;
			phone.TypeCode = "HP";
			phone.Number = "111-111-1111";
			phone.NameID = nameId;

			//Submit Phone object and set keys
			List<Key> keys = client.Submit(phone);

			//Use keys to get new Phone object from database
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
			NameEvent nameEvent = new NameEvent();

			//Fill out info - Operation, EventDate = DateTime.Now, EventEndDate = DateTime.Now.AddHours(2), TypeCode = "ARR", NameID
			nameEvent.Operation = OperationType.Insert;
			nameEvent.EventDate = DateTime.Now;
			nameEvent.EventEndDate = DateTime.Now.AddHours(2);
			nameEvent.TypeCode = "ARR";
			nameEvent.NameID = nameId;
			nameEvent.Title = "My Name Event";

			//Submit NameEvent and set keys
			List<Key> keys = client.Submit(nameEvent);

			//Use keys to get new NameEvent object from database
			int nameEventId = keys[0].NewID;
			NameEvent newNameEvent = client.GetNameEvent(nameEventId);

			//Return new NameEvent
			return newNameEvent;
		}

		public NameAttribute AddNameAttributes(JustWareApiClient client, int nameId)
		{
			//Create NameAttribute object
			NameAttribute attribute = new NameAttribute();

			//Fill out info - Operation, TypeCode = "WARR", NameID
			attribute.Operation = OperationType.Insert;
			attribute.TypeCode = "WARR";
			attribute.NameID = nameId;

			//Submit NameAttribute and set keys
			List<Key> keys = client.Submit(attribute);

			//Use keys to get new NameAttribute object from database
			int attributeId = keys[0].NewID;
			NameAttribute newAttribute = client.GetNameAttribute(attributeId);

			//Return new NameAttribute
			return newAttribute;
		}

		public NameNote AddNameNotes(JustWareApiClient client, int nameId)
		{
			//Create NameNote object
			NameNote note = new NameNote();

			//Fill out info - Operation, DateTaken = DateTime.Now, Notes, TakenBy = client.GetCallerNameID(), NameId
			note.Operation = OperationType.Insert;
			note.DateTaken = DateTime.Now;
			note.Notes = "Some notes";
			note.TakenBy = nameId;
			note.NameID = nameId;

			//Submit NameNote and set keys
			List<Key> keys = client.Submit(note);

			//Use keys to get new NameNote object from database
			int noteId = keys[0].NewID;
			NameNote newNote = client.GetNameNote(noteId);

			//Return new NameNote
			return newNote;
		}

		public NameTask AddNameTask(JustWareApiClient client, int nameId)
		{
			//Create NameTask object
			NameTask task = new NameTask();

			//Fill out info - Operation, EventDate = DateTime.Now, EventEndDate = DateTime.Now.AddHours(1), TypeCode = "TASK", Title, NameID
			task.Operation = OperationType.Insert;
			task.EventDate = DateTime.Now;
			task.EventEndDate = DateTime.Now.AddHours(1);
			task.TypeCode = "TASK";
			task.Title = "My Name Task";
			task.NameID = nameId;

			//Submit NameTask and set keys
			List<Key> keys = client.Submit(task);

			//Use keys to get new NameTask object from database
			int taskId = keys[0].NewID;
			NameTask newTask = client.GetNameTask(taskId, null);

			//Return new NameTask
			return newTask;
		}
	}
}
