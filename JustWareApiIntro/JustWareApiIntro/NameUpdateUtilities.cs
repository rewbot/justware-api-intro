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
	}
}
