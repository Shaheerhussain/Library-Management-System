<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="library.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="imgs/home-bg.jpg" class="img-fluid" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h2>Our 3 Primary Features 
                    </h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/digital-inventory.png" />
                    <h3>Book Inventory</h3>
                    <p class="text-justify">A book inventory records the amount of books currently in stock at a store, library, or collection. </p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/search-online.png" />
                    <h3>Search Books</h3>
                    <p class="text-justify">Any library member should be able to search books by their title, author, subject category as well by the publication date.</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/defaulters-list.png" />
                    <h3>Defaulter List</h3>
                    <p> All the Memebers who's Due date is Passed will be added to defaulter's List and Fine will be charged 20 Rs per day  </p>
                </div>
            </div>
        </div>
    </section>

    <section>
        <img src="imgs/in-homepage-banner.jpg" class="img-fluid" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h2>Our 3 Step Process</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/sign-up.png" />
                    <h3>Sign Up</h3>
                    <p class="text-justify">We have two types of accounts in the system, one will be a general member, and the other will be a librarian. </p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/search-online.png" />
                    <h3>Search Books</h3>
                    <p class="text-justify">Any library member should be able to search books by their title, author, subject category as well by the publication date.</p>
                </div>
                <div class="col-md-4 text-center">
                    <img width="150px" src="imgs/library.png" />
                    <h3>Visit Us</h3>
                    <p class="text-justify">Visit our library to borrow a book of amazing authors and publishers with a bunch of knowledge, from our library.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
