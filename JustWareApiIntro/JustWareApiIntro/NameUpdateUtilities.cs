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
		public Name UpdateName(JustWareApiClient client, Name name)
		{
			Name updateName = new Name();

			updateName.ID = name.ID;
			updateName.Operation = OperationType.Update;
			updateName.Weight = 120;
			updateName.WeightIsChanged = true;

			client.Submit(updateName);

			return client.GetName(updateName.ID, null);
		}

		public Phone UpdatePhones(JustWareApiClient client, Phone phone)
		{
			Phone updatePhone = new Phone();

			updatePhone.Operation = OperationType.Update;
			updatePhone.ID = phone.ID;
			updatePhone.Number = "222-222-2222";
			updatePhone.NumberIsChanged = true;

			client.Submit(updatePhone);

			return client.GetPhone(phone.ID);
		}

		public Address UpdateAddresses(JustWareApiClient client, Address address)
		{
			Address updateAddress = new Address();

			updateAddress.Operation = OperationType.Update;
			updateAddress.ID = address.ID;
			updateAddress.Zip = "84321";
			updateAddress.ZipIsChanged = true;

			client.Submit(updateAddress);

			return client.GetAddress(address.ID);
		}

		public Email UpdateEmail(JustWareApiClient client, Email email)
		{
			Email updateEmail = new Email();

			updateEmail.Operation = OperationType.Update;
			updateEmail.ID = email.ID;
			updateEmail.Address = "myEmail@somewhere.com";
			updateEmail.AddressIsChanged = true;

			client.Submit(updateEmail);

			return client.GetEmail(email.ID);
		}

		public NameEvent UpdateNameEvents(JustWareApiClient client, NameEvent nameEvent)
		{
			NameEvent updateNameEvent = new NameEvent();

			updateNameEvent.Operation = OperationType.Update;
			updateNameEvent.ID = nameEvent.ID;
			updateNameEvent.Title = "My Updated Event";
			updateNameEvent.TitleIsChanged = true;

			client.Submit(updateNameEvent);

			return client.GetNameEvent(nameEvent.ID);
		}

		public NameAttribute UpdateNameAttributes(JustWareApiClient client, NameAttribute nameAttribute)
		{
			NameAttribute updateNameAttribute = new NameAttribute();

			updateNameAttribute.Operation = OperationType.Update;
			updateNameAttribute.ID = nameAttribute.ID;
			updateNameAttribute.TypeCode = "INC";
			updateNameAttribute.TypeCodeIsChanged = true;

			client.Submit(updateNameAttribute);

			return client.GetNameAttribute(nameAttribute.ID);
		}

		public NameNote UpdateNameNotes(JustWareApiClient client, NameNote nameNote)
		{
			NameNote updateNameNote = new NameNote();

			updateNameNote.Operation = OperationType.Update;
			updateNameNote.ID = nameNote.ID;
			updateNameNote.Notes = "My updated notes";
			updateNameNote.NotesIsChanged = true;

			client.Submit(updateNameNote);

			return client.GetNameNote(nameNote.ID);
		}

		public NameTask UpdateNameTasks(JustWareApiClient client, NameTask nameTask)
		{
			NameTask updateNameTask = new NameTask();

			updateNameTask.Operation = OperationType.Update;
			updateNameTask.ID = nameTask.ID;
			updateNameTask.Title = "My Updated Task";
			updateNameTask.TitleIsChanged = true;

			client.Submit(updateNameTask);

			return client.GetNameTask(nameTask.ID, null);
		}
	}
}
