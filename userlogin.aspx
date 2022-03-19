<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="library.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <h3>User Login</h3>
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                                <br />
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <br />
                                <div class="form-group">
                                    <center>
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Width="250px"  Text="Login" OnClick="Button1_Click"  />
                               </center>
                                </div>
                                <br />
                                <div class="form-group">

                                    <a href="usersignup.aspx">
                                        <center>
                                        <input class="btn btn-info btn-block btn-lg" id="Button2" type="button" style="width:250px;" value="Sign Up"  />
                                    </a>
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <a href="homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
