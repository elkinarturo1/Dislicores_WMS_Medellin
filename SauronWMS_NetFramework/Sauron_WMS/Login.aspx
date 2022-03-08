<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="../EstilosLogin/images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/fonts/iconic/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/animsition/css/animsition.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/vendor/daterangepicker/daterangepicker.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/css/util.css">
    <link rel="stylesheet" type="text/css" href="../EstilosLogin/css/main.css">
    <!--===============================================================================================-->

</head>
<body>

        <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-26">Dislicores
                    </span>
                    <span class="login100-form-title p-b-48">
                        Sauron WMS
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="Valid email is: a@b.c">
                        <asp:TextBox class="input100" ID="txtUtuario" type="text" name="email" runat="server"></asp:TextBox>                        
                        <span class="focus-input100" data-placeholder="Email"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Enter password">
                        <span class="btn-show-pass">
                            <i class="zmdi zmdi-eye"></i>
                        </span>
                           <asp:TextBox class="input100" ID="txtClave" type="password" name="pass" runat="server"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="Password"></span>
                    </div>

                    <div class="container-login100-form-btn">
                        <div class="wrap-login100-form-btn">
                            <div class="login100-form-bgbtn"></div>
                            <asp:Button class="login100-form-btn" ID="btnIngresar" runat="server" Text="Ingresar" BackColor="#3435cc" />                         
                        </div>
                    </div>

                       <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

                    <div class="text-center p-t-115">
                        <span class="txt1">Don’t have an account?
                        </span>

                        <a class="txt2" href="#">Sign Up
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="EstilosLogin/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="EstilosLogin/vendor/animsition/js/animsition.min.js"></script>
    <script src="EstilosLogin/vendor/bootstrap/js/popper.js"></script>
    <script src="EstilosLogin/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="EstilosLogin/vendor/select2/select2.min.js"></script>
    <script src="EstilosLogin/vendor/daterangepicker/moment.min.js"></script>
    <script src="EstilosLogin/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="EstilosLogin/vendor/countdowntime/countdowntime.js"></script>
    <script src="EstilosLogin/js/main.js"></script>
    <!--===============================================================================================-->
  
</body>
</html>
