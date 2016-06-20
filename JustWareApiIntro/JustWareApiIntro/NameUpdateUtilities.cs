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

			return client.GetAddress(addressId);
		}

		public Email UpdateEmail(JustWareApiClient client, int emaiId)
		{
			Email updateEmail = new Email();

			updateEmail.Operation = OperationType.Update;
			updateEmail.ID = emaiId;
			updateEmail.Address = "myEmail@somewhere.com";
			updateEmail.AddressIsChanged = true;

			client.Submit(updateEmail);

			return client.GetEmail(emaiId);
		}

		public NameEvent UpdateNameEvents(JustWareApiClient client, int nameEventId)
		{
			NameEvent updateNameEvent = new NameEvent();

			updateNameEvent.Operation = OperationType.Update;
			updateNameEvent.ID = nameEventId;
			updateNameEvent.Title = "My Updated Event";
			updateNameEvent.TitleIsChanged = true;

			client.Submit(updateNameEvent);

			return client.GetNameEvent(nameEventId);
		}

		public NameAttribute UpdateNameAttributes(JustWareApiClient client, int nameAttributeId)
		{
			NameAttribute updateNameAttribute = new NameAttribute();

			updateNameAttribute.Operation = OperationType.Update;
			updateNameAttribute.ID = nameAttributeId;
			updateNameAttribute.TypeCode = "INC";
			updateNameAttribute.TypeCodeIsChanged = true;

			client.Submit(updateNameAttribute);

			return client.GetNameAttribute(nameAttributeId);
		}

		public NameNote UpdateNameNotes(JustWareApiClient client, int nameNoteId)
		{
			NameNote updateNameNote = new NameNote();

			updateNameNote.Operation = OperationType.Update;
			updateNameNote.ID = nameNoteId;
			updateNameNote.Notes = "My updated notes";
			updateNameNote.NotesIsChanged = true;

			client.Submit(updateNameNote);

			return client.GetNameNote(nameNoteId);
		}

		public NameTask UpdateNameTasks(JustWareApiClient client, int nameTaskId)
		{
			NameTask updateNameTask = new NameTask();

			updateNameTask.Operation = OperationType.Update;
			updateNameTask.ID = nameTaskId;
			updateNameTask.Title = "My Updated Task";
			updateNameTask.TitleIsChanged = true;

			client.Submit(updateNameTask);

			return client.GetNameTask(nameTaskId, null);
		}
	}
}
