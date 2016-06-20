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

		public Phone AddPhones(JustWareApiClient client, int nameId)
		{
			//Create Phone object
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

		public Email AddEmail(JustWareApiClient client, int nameId)
		{
			Email email = new Email();
			email.Operation = OperationType.Insert;
			email.TypeCode = "BUS";
			email.Address = "someone@somewhere.com";
			email.NameID = nameId;

			List<Key> keys = client.Submit(email);
			int emailId = keys[0].NewID;
			Email newEmail = client.GetEmail(emailId);

			return newEmail;
		}

		public Address AddAddresses(JustWareApiClient client, int nameId)
		{
			Address address = new Address();
			address.Operation = OperationType.Insert;
			address.TypeCode = "HA";
			address.StateCode = "UT";
			address.City = "Logan";
			address.Zip = "84405";
			address.StreetAddress = "843 South 100 West";
			address.NameID = nameId;

			List<Key> keys = client.Submit(address);
			int addressId = keys[0].NewID;
			Address newAddress = client.GetAddress(addressId);

			return newAddress;
		}

		public NameAttribute AddNameAttributes(JustWareApiClient client, int nameId)
		{
			NameAttribute attribute = new NameAttribute();
			attribute.Operation = OperationType.Insert;
			attribute.TypeCode = "WARR";
			attribute.NameID = nameId;

			List<Key> keys = client.Submit(attribute);
			int attributeId = keys[0].NewID;
			NameAttribute newAttribute = client.GetNameAttribute(attributeId);

			return newAttribute;
		}

		public NameEvent AddNameEvents(JustWareApiClient client, int nameId)
		{
			NameEvent nameEvent = new NameEvent();
			nameEvent.Operation = OperationType.Insert;
			nameEvent.EventDate = DateTime.Now;
			nameEvent.EventEndDate = DateTime.Now.AddHours(2);
			nameEvent.TypeCode = "ARR";
			nameEvent.NameID = nameId;
			nameEvent.Title = "My Name Event";

			List<Key> keys = client.Submit(nameEvent);
			int nameEventId = keys[0].NewID;
			NameEvent newNameEvent = client.GetNameEvent(nameEventId);

			return newNameEvent;
		}

		public NameNote AddNameNotes(JustWareApiClient client, int nameId)
		{
			NameNote note = new NameNote();
			note.Operation = OperationType.Insert;
			note.DateTaken = DateTime.Now;
			note.Notes = "Some notes";
			note.TakenBy = nameId;
			note.NameID = nameId;

			List<Key> keys = client.Submit(note);
			int noteId = keys[0].NewID;
			NameNote newNote = client.GetNameNote(noteId);

			return newNote;
		}

		public NameTask AddNameTask(JustWareApiClient client, int nameId)
		{
			NameTask task = new NameTask();
			task.Operation = OperationType.Insert;
			task.EventDate = DateTime.Now;
			task.EventEndDate = DateTime.Now.AddHours(1);
			task.TypeCode = "TASK";
			task.Title = "My Name Task";
			task.NameID = nameId;

			List<Key> keys = client.Submit(task);
			int taskId = keys[0].NewID;
			NameTask newTask = client.GetNameTask(taskId, null);

			return newTask;
		}
	}
}
