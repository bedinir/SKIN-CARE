# Skin Care Web Application

Welcome to the Skin Care Web Application! This is a comprehensive web application designed to provide users with a personalized skincare routine based on their skin type and concerns.

## Features

- **User Registration and Authentication:** Users can register and authenticate using an email address and password combination through input fields on the registration form.
- **Skin Type Identification:** The application helps users identify their skin type through a simple questionnaire.
- **Routine Recommendation:** Based on the user's skin type and concerns, the application recommends a customized skincare routine.
- **Product Recommendations:** Users can explore recommended skincare products tailored to their needs.
- **Product Reviews:** Users can leave reviews for products they have tried, helping others make informed decisions.
- **Community Forum:** A platform for users to ask questions, share tips, and discuss skincare-related topics.
- **User Management:** Normal users can view products, categories, and brands. They can also change their passwords.
- **Admin Panel:** Admins can manage products, categories, brands, and users through a dedicated admin panel. This includes functionalities such as inserting, deleting, and updating products, categories, and brands, as well as managing user accounts and moderating content. Admins can also change their passwords.

## Technologies Used

- **Framework:** .NET Core
- **Database:** Entity Framework Core (Code First approach)
- **Frontend:** HTML, CSS, JavaScript (using Razor Pages or MVC)
- **Additional Tools:** Bootstrap, jQuery

## Installation

To run the Skin Care Web Application locally, follow these steps:

1. Clone the repository to your local machine.
2. Install the .NET Core SDK if you haven't already.
3. Navigate to the project directory in your terminal.
4. Run `dotnet ef database update` to apply migrations and create the database.
5. Run `dotnet run` to start the application.
6. Access the application through your web browser at `http://localhost:5000`.

## Usage

1. Register for an account or log in if you already have one.
2. Explore the recommended skincare routine and products.
4. Access the admin panel using the provided admin credentials to manage products, categories, brands, and users.
5. Normal users can view products, categories, and brands. They can also change their passwords.

## Admin Panel

The admin panel provides the following functionalities:

- **Product Management:** Add, edit, or delete skincare products.
- **Category Management:** Add, edit, or delete product categories.
- **Brand Management:** Add, edit, or delete product brands.
- **Password Management:** Admins can change their passwords.

To access the admin panel, log in using the provided admin credentials.

## Admin Profile Creation

To create an admin profile, follow these steps:

1. Open your preferred database management tool (e.g., SQL Server Management Studio).
2. Insert a new record into the `AspNetRoles` table with the name "Admin".
3. Retrieve the `Id` of the newly created role from the `AspNetRoles` table.
4. Insert a new record into the `AspNetUserRoles` table with the `UserId` of the user you want to assign admin privileges to and the `RoleId` retrieved in step 3.

## Acknowledgements

We would like to thank the following resources for their valuable contributions:

- [.NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Bootstrap](https://getbootstrap.com/)
- [jQuery](https://jquery.com/)
