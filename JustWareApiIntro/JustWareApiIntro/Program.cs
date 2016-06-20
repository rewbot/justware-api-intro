﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustWareApiIntro.JustWareApi;

namespace JustWareApiIntro
{
	class Program
	{
		static void Main(string[] args)
		{
			JustWareApiClient client = GetClient();
			if (client == null)
			{
				Console.WriteLine("JustWareApi Client has not been initialized.");
				Console.Write("\nPress Enter to finish...");
				Console.ReadLine();

				return;
			}
			//Verify that connection is working
			int callerNameId = client.GetCallerNameID();
			Console.WriteLine("Caller NameID: " + callerNameId);

			//Name Insert
			NameInsertUtilities insertUtil = new NameInsertUtilities();
			Name name = insertUtil.InsertName(client);

			int nameId = name.ID;
			Phone phone = insertUtil.AddPhones(client, nameId);
			Address address = insertUtil.AddAddresses(client, nameId);
			Email email = insertUtil.AddEmail(client, nameId);
			NameEvent nameEvent = insertUtil.AddNameEvents(client, nameId);
			NameAttribute nameAttribute = insertUtil.AddNameAttributes(client, nameId);
			NameNote nameNote = insertUtil.AddNameNotes(client, nameId);
			NameTask nameTask = insertUtil.AddNameTask(client, nameId);

			Console.WriteLine("\nNew Name Information:\n");
			OutputNameInformation(GetNameWithCollections(client, name));

			//Name Update
			NameUpdateUtilities updateUtil = new NameUpdateUtilities();
			Name updatedName = updateUtil.UpdateName(client, nameId);
			Phone updatedPhone = updateUtil.UpdatePhones(client, phone.ID);
			Address updatedAddress = updateUtil.UpdateAddresses(client, address.ID);
			Email updatedEmail = updateUtil.UpdateEmail(client, email.ID);
			NameEvent updatedNameEvent = updateUtil.UpdateNameEvents(client, nameEvent.ID);
			NameAttribute updatedNameAttribute = updateUtil.UpdateNameAttributes(client, nameAttribute.ID);
			NameNote updatedNameNote = updateUtil.UpdateNameNotes(client, nameNote.ID);
			NameTask updatedNameTask = updateUtil.UpdateNameTasks(client, nameTask.ID);

			Console.WriteLine("\nUpdated Name Information:\n");
			OutputNameInformation(GetNameWithCollections(client, updatedName));

			//NameDelete
			CleanupName(client, name);

			Console.Write("\nPress Enter to finish...");
			Console.ReadLine();
		}

		private static Name GetNameWithCollections(JustWareApiClient client, Name name)
		{
			List<string> collections = new List<string>();
			collections.Add("Phones");
			collections.Add("Addresses");
			collections.Add("Emails");
			collections.Add("Events");
			collections.Add("Attributes");
			collections.Add("Notes");
			collections.Add("Tasks");

			Name nameWithCollections = client.GetName(name.ID, collections);

			return nameWithCollections;
		}

		private static void OutputNameInformation(Name name)
		{
			Console.WriteLine("Last: {0}", name.Last);
			Console.WriteLine("First: {0}", name.First);
			Console.WriteLine("DateOfBirth: {0}", name.DateOfBirth);
			Console.WriteLine("Weight: {0}", name.Weight);
			Console.WriteLine("DriversLicenseNumber: {0}", name.DriversLicenseNumber);

			if (name.Phones.Count > 0)
			{
				Console.WriteLine("Phones: {0}", name.Phones[0].Number);
			}
			if (name.Addresses.Count > 0)
			{
				Console.WriteLine("Addresses: {0}, {1}, {2} {3}", name.Addresses[0].StreetAddress, name.Addresses[0].City, name.Addresses[0].StateCode, name.Addresses[0].Zip);
			}
			if (name.Emails.Count > 0)
			{
				Console.WriteLine("Emails: {0}", name.Emails[0].Address);
			}
			if (name.Events.Count > 0)
			{
				Console.WriteLine("Events: {0} {1}", name.Events[0].Title, name.Events[0].EventDate);
			}
			if (name.Attributes.Count > 0)
			{
				Console.WriteLine("Name Attributes: {0}", name.Attributes[0].TypeCode);
			}
			if (name.Notes.Count > 0)
			{
				Console.WriteLine("Notes: {0}", name.Notes[0].Notes);
			}
			if (name.Tasks.Count > 0)
			{
				Console.WriteLine("Tasks: {0} {1}", name.Tasks[0].Title, name.Tasks[0].EventDate);
			}
		}

		private static void CleanupName(JustWareApiClient client, Name name)
		{
			Console.WriteLine("\nDeleting name...");
			name.Operation = OperationType.Delete;
			client.Submit(name);
		}

		private static JustWareApiClient GetClient()
		{
			JustWareApiClient client = new JustWareApiClient();
			client.ClientCredentials.UserName.UserName = @"tc\User";
			client.ClientCredentials.UserName.Password = "JustWare5";

			return client;
		}
	}
}
