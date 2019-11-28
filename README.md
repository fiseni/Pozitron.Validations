<img align="left" src="pozitronlogo.png" width="120" height="120">

&nbsp; [![NuGet](https://img.shields.io/nuget/v/PozitronDev.Validations.svg)](https://www.nuget.org/packages/PozitronDev.Validations)[![NuGet](https://img.shields.io/nuget/dt/PozitronDev.Validations.svg)](https://www.nuget.org/packages/PozitronDev.Validations)

&nbsp; [![Build Status](https://dev.azure.com/pozitrongroup/PozitronDev.Validations/_apis/build/status/fiseni.PozitronDev.Validations?branchName=master)](https://dev.azure.com/pozitrongroup/PozitronDev.Validations/_build/latest?definitionId=7&branchName=master)

&nbsp; [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/pozitrongroup/PozitronDev.Validations/7.svg)](https://dev.azure.com/pozitrongroup/PozitronDev.Validations/_build/latest?definitionId=7&branchName=master)


# PozitronDev Validations

Nuget package for validating various inputs against invalid values. If validation fails appropriate exception is thrown.

## Usage

Validation rules are implemented as extension methods to `ValidateFor` (`IValidate<T>`) clause. Therefore, distinct validation methods are available based on the type of the object being extended.

All validation methods accept optional `parameterName` argument. If the argument is ommited, the name of the underlying type is used to construct the exception messages.

Inline usages are possible too, since all extensions return the input object. 

- Argument validation example

```c#
    public void CreateCart(Customer customer)
    {
        customer.ValidateFor().Null();

        // create cart here
    }
```

- Inline usage example:

```c#
    public Address GetCustomerAddress(Customer customer)
    {
        return customer.ValidateFor().Null().Address;
    }
```

- Various validations based on the type:

```c#
    object myObject;
    myObject.ValidateFor().Null();
    myObject.ValidateFor().Null(nameof(myObject));

    string myString;
    myString.ValidateFor().NullOrEmpty();
    myString.ValidateFor().NullOrWhiteSpace();
    myString.ValidateFor().NullOrEmpty(nameof(myString));
    myString.ValidateFor().NullOrWhiteSpace(nameof(myString));

    int myInt;
    myInt.ValidateFor().Default();
    myInt.ValidateFor().Default(nameof(myInt));

    IEnumerable<T> myList;
    myList.ValidateFor().NullOrEmpty();
    myList.ValidateFor().NullOrEmpty(nameof(myList));

    Customer myCustomer = repo.GetByID(1);
    myCustomer.ValidateFor().NotFound(1);
    myCustomer.ValidateFor().NotFound(1, nameof(myCustomer));

```




## Supported Validation Rules

- `T.IValidate<T>.Null<T>(string parameterName = null)`
  - For T as class or nullable ValueType
  - Throws if input is null

- `T.IValidate<T>.NullOrEmpty<T>(string parameterName = null)`
  - For T as string
  - Throws if input string is null or empty

- `T.IValidate<T>.Null<T>(string parameterName = null)`
  - For T as string
  - Throws if input string is null, empty or whitespace

- `T.IValidate<T>.Default<T>(string parameterName = null)`
  - Throws if input is default value for type T

- `IEnumerable<T>.IValidate<IEnumerable<T>>.NullOrEmpty<T>(string parameterName = null)`
  - Throws if input is null or empty collection

- `T.IValidate<T>.NotFound<T, TKey>(TKey key, string parameterName = null)`
  - For T as class, TKey as not nullable struct
  - Throws if input (the queried object by key value) is null.
  - Throws NotFoundException, custom exception defined in this package.

## Extending with your own validation rules

To extend IValidate with your own rules, you can do the following:

```c#
namespace PozitronDev.Validations
{
    public static class MyExtension
    {
        public static int MinQuantity(this IValidate<int> validateClause)
        {
            if (validateClause.Input < 1)
            {
                throw new ArgumentException($"Required quantity should not be less than 1.");
            }

            return validateClause.Input;
        }
    }
}
```
```c#
// Usage
public void Buy(int quantity, decimal price)
{
    quantity.ValidateFor().MinQuantity();

    var total = price * quantity;
    
    // Some processing
}
```
```c#
// Inline usage
public void Buy(int quantity, decimal price)
{
    var total = price * quantity.ValidateFor().MinQuantity();
    
    // Some processing
}
```

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!
