<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="OurProject.Signup" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Signup Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .signup-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        label {
            display: block;
            margin-bottom: 8px;
        }

        input {
            width: 100%;
            padding: 10px;
            margin-bottom: 16px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        button {
            background-color: #4caf50;
            color: #fff;
            padding: 12px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
        }

        .login-link {
            margin-top: 10px;
            text-align: center;
        }

            .login-link a {
                color: #007bff;
                text-decoration: none;
            }
    </style>
</head>
<body>

    <form id="signupForm" runat="server">
        <div class="signup-container">
            <h2>Signup</h2>
            <div>
                <label for="name">Name:</label>
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" Required="true" />
            </div>

            <div>
                <label for="username">Username:</label>
                <asp:TextBox runat="server" ID="username" CssClass="form-control" TextMode="SingleLine" Required="true" />
            </div>

            <div>
                <label for="email">Email:</label>
                <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" Required="true" />
            </div>

            <div>
                <label for="password">Password:</label>
                <asp:TextBox runat="server" ID="password" CssClass="form-control" TextMode="Password" Required="true" />
            </div>

            <div>
                <label for="confirmPassword">Confirm Password:</label>
                <asp:TextBox runat="server" ID="confirmPassword" CssClass="form-control" TextMode="Password" Required="true" />
            </div>

            <div>
                <label for="dob">Date of Birth:</label>
                <asp:TextBox runat="server" ID="dob" CssClass="form-control" TextMode="Date" Required="true" />
            </div>

            <div>
                <asp:Button runat="server" ID="signupButton" Text="Signup" OnClick="SignupButton_Click" />
            </div>

            <div class="login-link">
                Already have an account? <a href="login.aspx">Login</a>
            </div>
        </div>
    </form>

</body>
</html>
