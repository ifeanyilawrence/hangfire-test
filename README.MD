# HangFire Background Processing #

A simple example of how to schedule an automated task to run at specified intervals

## Features ##

* **HangFire Package**
* **ASP.NET Core MVC**

### NB: Use HangFire v 1.7.6 to avoid sql compatibilty issues ###
The jobs are registered on the startup class (e.g MailService)
You can implement the MailService for a periodic mail sending