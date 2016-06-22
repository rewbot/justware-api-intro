using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustWareApiIntro.JustWareApi;

namespace JustWareApiIntro
{
	public class NameUpdateUtilities
	{
		public void UpdateName(JustWareApiClient client, int nameId)
		{
			//Create Object

			//Fill out required info

			//Fill out info to be updated

			//Submit
		}

		public void UpdatePhones(JustWareApiClient client, int phoneId)
		{
			//Create Object

			//Fill out required info

			//Fill out info to be updated

			//Submit
		}

		public void UpdateAddresses(JustWareApiClient client, int addressId)
		{
			//Create Address object

			//Fill out info - Operation, ID, Zip, ZipIsChanged

			//Submit Address
		}

		public void UpdateEmail(JustWareApiClient client, int emaiId)
		{
			//Create Email object

			//Fill out info - Operation, ID, Address, AddressIsChanged

			//Submit Email
		}

		public void UpdateNameEvents(JustWareApiClient client, int nameEventId)
		{
			//Create NameEvent

			//Fill out info - Operation, ID, Title, TitleIsChanged

			//Submit NameEvent
		}

		public void UpdateNameAttributes(JustWareApiClient client, int nameAttributeId)
		{
			//Create NameAttribute object

			//Fill out info - Operation, ID, TypeCode = "INC", TypeCodeIsChanged

			//Submit NameAttribute object
		}

		public void UpdateNameNotes(JustWareApiClient client, int nameNoteId)
		{
			//Create NameNote object

			//Fill out info - Operation, ID, Notes, NotesIsChanged

			//Submit NameNote
		}

		public void UpdateNameTasks(JustWareApiClient client, int nameTaskId)
		{
			//Create NameTask object

			//Fill out info - Operation, ID, Title, TitleIsChanged

			//Submit NameTask
		}
	}
}
