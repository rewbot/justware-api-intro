# Introduction to JustWare API Coding
Welcome to a beginning introduction to using the JustWare API

This project is a console application written in C# that demonstrates the basic concepts of the JustWare API. The API is based on entities. You can interact with entities by using a Submit, GetEntity, or FindEntity. A list of entities and required fields can be found in the Entities section of the [API Documentation](http://www.documentation.newdawn.com/api/). The training covers the following:

- Inserts (entity and entity collections)
- Updates (entity and entity collections)
- Deletes
- Gets

To setup the API service reference:

1. In the Solution Explorer, right click on References -> Add Service Reference... The "Add Service Reference Dialog" should be visible.
2. In the address portion paste your JustWare API URL and click Go. You will be prompted to authenticate the request. Click Yes and input the username and password for your JustWare API user.
3. Change the Namespace name to JustWareApi and then click Advanced...
4. Uncheck "Allow generation of asynchronous operations" 
5. In the Data Type section click the Collection Type dropdown and change it to System.Collections.Generic.List
6. Click OK, and then click Ok again on the main dialog. The reference errors in the application should now be resolved.

For more information on setting up your own API check out the Getting Started section of the [API Documentation](http://www.documentation.newdawn.com/api/).

#### 1. Initialize the Client
> Run `git checkout initialize-client` to complete this step

To start you will need to initialize the JustWare API client. Go to `Program.cs` and find the method `GetClient()`. Add the following lines to that method:

```csharp
JustWareApiClient client = new JustWareApiClient();
client.ClientCredentials.UserName.UserName = @"tc\User";
client.ClientCredentials.UserName.Password = "JustWare5";
```

You'll want to verify that the connection to the API is working. A good way to do this is to call `GetCallerNameID()` since it requires no data. In `Program.cs` in the `Main` method, line 25, add the following lines:

```csharp
int nameId = client.GetCallerNameID();
Console.WriteLine("Caller NameID: " + nameId);
```

Hit F5 to run the program and verify that your caller NameID is printed to the console.

####2. Insert a Name
> Run `git checkout insert-name` to complete this step

We will be following a basic pattern for inserting data

1. Create Entity Object
2. Fill out required info, including operation type
3. Fill out additional info
4. Submit the entity
5. Get the submitted item from the database

Open `NameInsertUtilities.cs` and add the following lines to `InsertName()` and in the drivers license number replace `[yourLastName]` with your last name:

```csharp
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
```

Anytime we deal with entities we need to set the operation type. In our case we are going to insert. When we perform a submit, the function will return a list of keys, giving us the JustWare IDs of the object we just submitted. In this case, we’ve only submitted a single object, so we will get a single item back in the list. We can then use that NameID to get the new name from the database as demonstrated with `client.GetName(nameId, null)`. 

Run the program and you should see the name information we added printed out in the console. In a real environment you'd want to check for existing names before you insert a new name. Add a call to `FindAndDeleteExistingNames(client)` at the beginning of the `InsertName()` method. This method uses the API to query the database for names. If you look at the method you'll see the query structured like this: `"Last = \"Thawne\" && First = \"Eobard\" && DriversLicenseNumber=\"[yourLastName]-12\""`. Again, replace `[yourLastName]` with your last name so that the query will find the name you inserted. You'll notice that this method deletes Name entities. To do so, you simply need the ID of the entity to delete and then set the entity `Operation` to `OperationType.Delete`. 

####3. Update a Name
> Run `git checkout update-name` to complete this step

This will follow a similar pattern to inserting with two exceptions. First, we will need an existing NameID and second, any properties that we want to update need the `IsChanged` property set to true. Open `NameUpdateUtilities.cs` and find the `UpdateNames()` method. Add the following lines to that method:

```csharp
//Create Object
Name updateName = new Name();

//Fill out required info
updateName.Operation = OperationType.Update;
updateName.ID = nameId; //The NameID of the name we just inserted

//Fill out info to be updated
updateName.Weight = 120;
updateName.WeightIsChanged = true; //note the IsChanged property for Weight

//Submit
client.Submit(updateName);
```

Run the program and you'll now notice that in the Updated Name Information section that weight is set to 120 instead of 150.

####4. Add Phone collection to a Name
> Run `git checkout add-phone-collection` to complete this step

We can add data collections to names. For this example we will be associating a Phone number with our name. This will follow almost the exact same pattern as inserting a name with one difference: we will need to associate the Phone number with Name by setting the NameID property on our Phone object. Go back to `NameInsertUtilities.cs` and add the following to the `AddPhones()` method:

```csharp
//Create phone object
Phone phone = new Phone();

//Fill out information
phone.Operation = OperationType.Insert;
phone.TypeCode = "HP";
phone.Number = "111-111-1111";
phone.NameID = nameId; //Associate the new Phone number with a name

//Submit
List<Key> keys = client.Submit(phone);

//Get object from database
int phoneId = keys[0].NewID;
Phone newPhone = client.GetPhone(phoneId);

return newPhone;
```

You can submit multiple Phone objects on the Name. You simply have to create another Phone object, fill out the required information and submit that object. 

There is another method for adding collections to an entity. The main difference is that we don't have to set the NameID on our collection entity. Instead you would add the Phone to the Phones collection of the name as demonstrated in `AddPhones2()`:

```csharp
public Phone AddPhones2(JustWareApiClient client, Name name)
{
	//Initialize collection on Name entity
	name.Phones = new List<Phone>();

	//Create object and fill out info
	Phone phone1 = new Phone();
	phone1.Operation = OperationType.Insert;
	phone1.TempID = "Phone1";
	phone1.TypeCode = "HP";
	phone1.Number = "111-111-1111";
	//Add the Phone to the Phones collection
	name.Phones.Add(phone1);

	//Submit the Name
	List<Key> keys = client.Submit(name);
	int phoneId = keys[0].NewID;

	return client.GetPhone(phoneId);
}
```

This method allows you to add multiple entity objects to a collections with only one submit. When we perform the Submit we will have a key returned for each object submitted. To determine which ID corresponds to which object you can specify a TempID when you are filling out the information for that object. You can then iterate over the keys and select the one you want based on the TempID name. Here is the `AddPhones2()` method with the updated changes:

```csharp
//Initialize collection on Name entity
name.Phones = new List<Phone>();

//Create object and fill out info
Phone phone1 = new Phone();
phone1.Operation = OperationType.Insert;
phone1.TempID = "Phone1"; //Set the TempID
phone1.TypeCode = "HP";
phone1.Number = "111-111-1111";
name.Phones.Add(phone1);

Phone phone2 = new Phone();
phone2.Operation = OperationType.Insert;
phone2.TempID = "Phone2"; //Set the TempID
phone2.TypeCode = "HP";
phone2.Number = "333-333-3333";
name.Phones.Add(phone2);

//Submit the Name
List<Key> keys = client.Submit(name);

int phoneId = 0;
foreach (Key key in keys)
{
	//We want the first Phone object
	if (key.TempID == "Phone1")
	{
		phoneId = key.NewID;
	}
}

return client.GetPhone(phoneId);
```

####5. Get Name with Collections

You may have noticed in the `GetName()` or `FindNames()` methods that there were 2 parameters. The second parameter we’ve always been specifying as null.  This parameter, IncludedCollections, allows us to specify which, if any, of the children objects to bring back. In our case we only have Phone collections to bring back. In `Program.cs` replace the contents of `GetNameWithCollections()` with the following:

```csharp
List<string> collections = new List<string>();
collections.Add("Phones");

Name nameWithCollections = client.GetName(nameId, collections);

return nameWithCollections;
```

Run the program and you should see Phones added to the name information printed to the console. a.	Lets go ahead and add in a few other collections to `GetNameWithCollections()` to bring back while we are here. You will need these later on. 

```csharp
collections.Add("Addresses");
collections.Add("Emails");
collections.Add("Events");
collections.Add("Attributes");
collections.Add("Notes");
collections.Add("Tasks");
```

**NOTE: In a real implementation you only want to return the collections you will actually be using.**

####6. Update Phone collection
> Run `git checkout update-phone` to complete this step

We will be following the same pattern as our Name update for updating Phones. Open `NameUpdateUtilities.cs` and add the following to `UpdatePhones`:

```csharp
//Create Object
Phone updatePhone = new Phone();

//Fill out required info
updatePhone.Operation = OperationType.Update;
updatePhone.ID = phoneId;

//Fill out info to be updated
updatePhone.Number = "222-222-2222";
updatePhone.NumberIsChanged = true; //note the IsChanged property for Number

//Submit
client.Submit(updatePhone);
```

Run the program and you should now see in the Updated Name Information sections an updated Phone number.

####7. Practice

There are stubbed out methods in `NameInsertUtilities.cs` and `NameUpdateUtilities.cs` for inserting and updating various Name collections. You'll need to have the insert method for a particular entity finished before you can implement the update method for that entity. The information you need to complete them is found in the comments of each block. The codes for each entity will vary depending on the database the API is pointed at. You can get the completed code for each insert/updae by running one of the following:

- `git checkout address`
- `git checkout email`
- `git checkout name-event`
- `git checkout name-attribute`
- `git checkout name-note`
- `git checkout name-task`

> Run `git checkout complete` if you want to get the completed project





