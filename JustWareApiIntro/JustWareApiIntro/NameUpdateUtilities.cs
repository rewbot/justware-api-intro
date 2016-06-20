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
		public Name UpdateName(JustWareApiClient client, int nameId)
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

			//Return updated Name from the database
			return client.GetName(nameId, null);
		}

		public Phone UpdatePhones(JustWareApiClient client, int phoneId)
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

			//Return updated Phone from the database
			return client.GetPhone(phoneId);
		}

		public Address UpdateAddresses(JustWareApiClient client, int addressId)
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

			//Get and return Address
			return client.GetAddress(addressId);
		}

		public Email UpdateEmail(JustWareApiClient client, int emaiId)
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

			//Get and return Email
			return client.GetEmail(emaiId);
		}

		public NameEvent UpdateNameEvents(JustWareApiClient client, int nameEventId)
		{
			//Create NameEvent
			NameEvent updateNameEvent = new NameEvent();

			//Fill out info - Operation, ID, Title, TitleIsChanged
			updateNameEvent.Operation = OperationType.Update;
			updateNameEvent.ID = nameEventId;
			updateNameEvent.Title = "My Updated Event";
			updateNameEvent.TitleIsChanged = true;

			//Submit NameEvent
			client.Submit(updateNameEvent);

			//Get and return NameEvent
			return client.GetNameEvent(nameEventId);
		}

		public NameAttribute UpdateNameAttributes(JustWareApiClient client, int nameAttributeId)
		{
			//Create NameAttribute object
			NameAttribute updateNameAttribute = new NameAttribute();

			//Fill out info - Operation, ID, TypeCode = "INC", TypeCodeIsChanged
			updateNameAttribute.Operation = OperationType.Update;
			updateNameAttribute.ID = nameAttributeId;
			updateNameAttribute.TypeCode = "INC";
			updateNameAttribute.TypeCodeIsChanged = true;

			//Submit NameAttribute object
			client.Submit(updateNameAttribute);

			//Get and return NameAttribute
			return client.GetNameAttribute(nameAttributeId);
		}

		public NameNote UpdateNameNotes(JustWareApiClient client, int nameNoteId)
		{
			//Create NameNote object
			NameNote updateNameNote = new NameNote();

			//Fill out info - Operation, ID, Notes, NotesIsChanged
			updateNameNote.Operation = OperationType.Update;
			updateNameNote.ID = nameNoteId;
			updateNameNote.Notes = "My updated notes";
			updateNameNote.NotesIsChanged = true;

			//Submit NameNote
			client.Submit(updateNameNote);

			//Get and return NameNote
			return client.GetNameNote(nameNoteId);
		}

		public NameTask UpdateNameTasks(JustWareApiClient client, int nameTaskId)
		{
			//Create NameTask object
			NameTask updateNameTask = new NameTask();

			//Fill out info - Operation, ID, Title, TitleIsChanged
			updateNameTask.Operation = OperationType.Update;
			updateNameTask.ID = nameTaskId;
			updateNameTask.Title = "My Updated Task";
			updateNameTask.TitleIsChanged = true;

			//Submit NameTask
			client.Submit(updateNameTask);

			//Get and return NameTask
			return client.GetNameTask(nameTaskId, null);
		}
	}
}
