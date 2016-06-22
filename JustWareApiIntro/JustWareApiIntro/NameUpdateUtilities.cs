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
			Name updateName = new Name();

			//Fill out required info
			updateName.Operation = OperationType.Update;
			updateName.ID = nameId;

			//Fill out info to be updated
			updateName.Weight = 120;
			updateName.WeightIsChanged = true;

			//Submit
			client.Submit(updateName);
		}

		public void UpdatePhones(JustWareApiClient client, int phoneId)
		{
			//Create Object
			Phone updatePhone = new Phone();

			//Fill out required info
			updatePhone.Operation = OperationType.Update;
			updatePhone.ID = phoneId;

			//Fill out info to be updated
			updatePhone.Number = "222-222-2222";
			updatePhone.NumberIsChanged = true;

			//Submit
			client.Submit(updatePhone);
		}

		public void UpdateAddresses(JustWareApiClient client, int addressId)
		{
			//Create Address object
			Address updateAddress = new Address();

			//Fill out info - Operation, ID, Zip, ZipIsChanged
			updateAddress.Operation = OperationType.Update;
			updateAddress.ID = addressId;
			updateAddress.Zip = "84321";
			updateAddress.ZipIsChanged = true;

			//Submit Address
			client.Submit(updateAddress);
		}

		public void UpdateEmail(JustWareApiClient client, int emaiId)
		{
			//Create Email object
			Email updateEmail = new Email();

			//Fill out info - Operation, ID, Address, AddressIsChanged
			updateEmail.Operation = OperationType.Update;
			updateEmail.ID = emaiId;
			updateEmail.Address = "myEmail@somewhere.com";
			updateEmail.AddressIsChanged = true;

			//Submit Email
			client.Submit(updateEmail);
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
