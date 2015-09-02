LiteDB.AspNet.Identity
=======================

This library was constructed based on the 
## MongoDB.AspNet.Identity ## 
from https://github.com/InspectorIT.


ASP.NET Identity provider that users LiteDB for storage



## Purpose ##

ASP.NET MVC 5 shipped with a new Identity system (in the Microsoft.AspNet.Identity.Core package) in order to support both local login and remote logins via OpenID/OAuth, but only ships with an
Entity Framework provider (Microsoft.AspNet.Identity.EntityFramework).

## News ##
__02-11-2014__ - [http://blogs.msdn.com/b/webdev/archive/2014/02/11/announcing-preview-of-microsoft-aspnet-identity-2-0-0-beta1.aspx](Microsoft has released Microsoft.AspNet.Identity v2 Beta 1). I will be addressing these issues and introducing them into the LiteDB.AspNet.Identity provider.

## Features ##
* Drop-in replacement ASP.NET Identity with LiteDB as the backing store.
* Requires only 1 LiteDb document type, while EntityFramework requires 5 tables
* Contains the same IdentityUser class used by the EntityFramework provider in the MVC 5 project template.
* Supports additional profile properties on your application's user model.
* Provides UserStore<TUser> implementation that implements the same interfaces as the EntityFramework version:
    * IUserStore<TUser>
    * IUserLoginStore<TUser>
    * IUserRoleStore<TUser>
    * IUserClaimStore<TUser>
    * IUserPasswordStore<TUser>
    * IUserSecurityStampStore<TUser>

## Instructions ##
These instructions assume you know how to set up LiteDB within an MVC application.

1. Create a new ASP.NET MVC 5 project, choosing the Individual User Accounts authentication type.
2. Remove the Entity Framework packages and replace with LiteDB Identity:

```PowerShell
Uninstall-Package Microsoft.AspNet.Identity.EntityFramework
Uninstall-Package EntityFramework
Install-Package LiteDB.AspNet.Identity
```
    
3. In ~/Models/IdentityModels.cs:
    * Remove the namespace: Microsoft.AspNet.Identity.EntityFramework
    * Add the namespace: LiteDB.AspNet.Identity
	* Remove the ApplicationDbContext class completely.
4. In ~/Controllers/AccountController.cs
    * Remove the namespace: Microsoft.AspNet.Identity.EntityFramework
    * Add the connection string name to the constructor of the UserStore. Or empty constructor will use DefaultConnection

```C#
public AccountController()
{
    this.UserManager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>("myDb.data");
    // OR 
    this.UserManager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>("DefaultConnection");
}
```

## Connection Strings ##
The UserStore has multiple constructors for handling connection strings. Here are some examples of the expected inputs and where the connection string should be located.

### 1. SQL Style ###
```C#
UserStore(string connectionNameOrPath)
```
<code>UserStore("LiteDBUsers")</code>

**web.config**
```xml
<add name="LiteDBUsers" connectionString="{YourDataBaseFile}" />
```

**OR**

```C#
UserStore(string connectionNameOrPath)
```
<code>UserStore("{YourDataBaseFile}")</code>


## Thanks To ##

Special thanks to [MaxiomTech InspectorIT](https://github.com/InspectorIT) project gave me the base for jumpstarting the LiteDB provider
