<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="OurProject.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <label style="padding: 0px 0px 0px 16px; font-weight: 500; margin: 0px;">
                    <a data-toggle="modal" data-target="#ModalCenter" onclick="ClearModal()" class="btn btn-labeled btn-primary" style="padding-left: 16px;">
                        <span class="btn-label">
                            <img class="ButtonImage" height="18" src='../../Content/imgs/plus-solid.svg'></span> User</a>
                </label>
                <input class="form-control ml-auto" style="width: 250px; margin-right: 18px; height: 38px; font-size: 14px;" id="myInput" type="text" placeholder="Search.." runat="server">
            </div>
        </div>
        <div class="card-body table-responsive">
            <table class="table table-hover fontSize text-center" id="myTableData">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th class="text-left">Name</th>
                        <th class="text-left">Email</th>
                        <th class="text-left">ParkingName</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="myTable">
                    <tr runat="server" id="NoRecords" visible="false">
                        <th colspan="7" class="NoRecords">
                            <h4 class="m-0 mt-3"><span class="badge badge-danger">No Data Found</span></h4>
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="UserRep">
                        <ItemTemplate>
                            <tr data-id='<%#Eval("ID") %>' class="EditData">
                                <th class="font-weight-normal"><%#Eval("ID") %></th>
                                <th class="font-weight-normal text-left"><%#Eval("Name") %></th>
                                <th class="font-weight-normal text-left"><%#Eval("Email") %></th>
                                <th class="font-weight-normal text-left"><%#Eval("ParkingName") %></th>
                                <th class="font-weight-normal p-0">
                                    <img class="DeleteData ml-1" height="18" src='../../Content/imgs/trash-alt-regular.svg'>
                                </th>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <div class="modal fade" id="ModalCenter" tabindex="-1" role="dialog" aria-labelledby="ModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLongTitle">New User</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="leave_code" runat="server" Value="0" />
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>Name</label>
                            <input type="text" class="form-control" id="name">
                        </div>
                        <div class="form-group col-md-6">
                            <label>Email</label>
                            <input type="email" class="form-control" id="email">
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>Password</label>
                            <input type="password" class="form-control" id="pass">
                        </div>
                        <div class="form-group col-md-6">
                            <label>Parking Name</label>
                            <input type="text" class="form-control" id="pName">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="return (ValidateAndSubmit())">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalCenterDelete" tabindex="-1" role="dialog" aria-labelledby="ModalCenterDeleteTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document" style="width: 350px;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalCenterDeleteTitle">Confirm Action</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="IDToDelete" runat="server" Value="0" />
                    Do you want to proceed?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-danger" onclick="return (ValidateAndDelete())">Delete</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#<%= myInput.ClientID%>').on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#myTable tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
            $('#myTableData').on('click', '.DeleteData', function (event) {
                event.stopPropagation();
                $('#<%= IDToDelete.ClientID%>').val($(this).parent().parent().attr("data-id"));
                $('#ModalCenterDelete').modal('toggle');
            });
        });
        function ClearModal() {
            $("#ModalLongTitle").html("New User");
            $('#name').val('');
            $('#email').val('');
            $('#pass').val('');
            $('#pName').val('');
        }
        function ValidateAndDelete() {
            $.ajax({
                type: "POST",
                url: 'AdminDashboard.aspx/DeleteUser',
                data: JSON.stringify({ UserId: $('#<%= IDToDelete.ClientID%>').val() }),
                contentType: "application/json",
                dataType: "json",
                success: function (response) {
                    if (response.d == "true") {
                        location.reload();
                        isValid = true;
                        return true;
                    }
                }
            });
        }
        function ValidateAndSubmit() {
            if ($('#name').val() == '' || $('#email').val() == '' || $('#pass').val() == '' || $('#pName').val() == '') {
                alert("Please fill all mandatory fields");
                return false;
            }
            $.ajax({
                type: "POST",
                url: 'AdminDashboard.aspx/AddUser',
                data: JSON.stringify({ Name: $('#name').val(), Pass: $('#pass').val(), PName: $('#pName').val(), Email: $('#email').val() }),
                contentType: "application/json",
                dataType: "json",
                success: function (response) {
                    if (response.d == "true") {
                        location.reload();
                        isValid = true;
                        return true;
                    }
                }
            });
        }
    </script>
</asp:Content>
