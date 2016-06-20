using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustWareApiIntro.JustWareApi;

namespace JustWareApiIntro
{
	class NameInsertUtilities
	{
		public Name InsertName(JustWareApiClient client)
		{
			//Look for existing name
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
			List<string> includedCollections = new List<string>();
			includedCollections.Add("Phones");
			Name dbName = client.GetName(nameId, includedCollections);

			return dbName;
		}

	}
}
