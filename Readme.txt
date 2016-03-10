This application shows you how to use NServiceBus 5 with MVC 5 and Ninject for a (very, very) simple and webshop. 

ASSOCIATED BLOGPOST
-------------------
http://blog.agilistic.nl/using-nservicebus-to-connect-two-webapplications-mvc-with-a-touch-of-cqrs/

REQUIREMENTS
------------
1. A LocalDb instance or SQL-Server (you have to change the connectionstrings manually in this case)
2. Visual Studio 2013+
3. NuGet extension should be installed in Visual Studio to automatically restore the NuGet packages

PROJECT STRUCTURE
-----------------
The solution is roughly divided into:

1. The webshop (and associated projects)
2. The CMS (and associated projects)
3. A few shared projects (Messages and Repositories)

RUNNING THE CODE
----------------
1. In LocalDb or your local SQL-Server instance, create an empty database called 'Samples.NServiceBus'. NServiceBus can automatically populate the database, but it can't create it
2. Open the solution (Samples.NServiceBus.sln, the other two are for AppHarbor deployment) and run it. It should start two websites:  
   - The webshop: http://localhost:58469
   - The CMS: http://localhost:58470
   - If the ports are different, you have to change them in both web.configs (Samples.CmsUrl or Samples.WebshopUrl)
3. Upon first visit, Entity Framework should automatically create (empty) databases. If this does not, you may have to manually change the connectionstrings in both web.configs or make sure that the security settings in both strings are correct;
4. NServiceBus does not require any special configuration, other than what's already specific in the web.config files (marked with a comment).
5. Sometimes, it does not work right away. You should close IIS Express entirely and restart the websites;

TRY IT ONLINE
-------------
You can also try the applications online:
http://examplesnservicebuswebshop.apphb.com
http://examplesnservicebuscms.apphb.com