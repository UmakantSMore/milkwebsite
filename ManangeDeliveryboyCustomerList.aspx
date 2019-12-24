<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="ManangeDeliveryboyCustomerList.aspx.cs" Inherits="ManangeDeliveryboyCustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="row">
                <div class="col-xs-12">
                    <!-- /.box -->
                    <div class="box">
                        <br />
                        <div class="text-center">
                            <b id="spnMessage" visible="false" runat="server"></b>
                        </div>
                        <br />                   
                      
                        <table>
                            <tr>
                                <td>
                                    <label for="exampleInputPassword1" style="width:250px;"></label></td>
                                <td>
                                    <label for="exampleInputPassword1" style="width:150px;">Select Delivery Boy</label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Width="10"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlDeliveryboy" Class="form-control" runat="server" Width="300px"  AutoPostBack="true" OnSelectedIndexChanged="ddlDeliveryboy_SelectedIndexChanged"  >
                                    </asp:DropDownList></td>

                                <%-- <td>
                                    <asp:Label ID="Label3" runat="server" Width="10"></asp:Label></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-flickr" OnClick="btnSave_Click" />

                                </td>   --%>

                            </tr>
                        
                          
                        </table>
                        <!-- /.box-body -->
                                              <!-- /.box-header -->
                        <div class="box-body" style="overflow: scroll;">
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                       
                                        <th style="text-align: center">Customer Id</th>
                                        <th style="text-align: center">Customer Name</th>                                      
                                         <th style="text-align: center">Action</th>
                                    </tr>

                                </thead>


                                <tbody>

                                    <asp:Repeater ID="repCustomer" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                               
                                                <td class="singleCheckbox" style="text-align: center">
                                                         
                                                     <asp:Label ID="lblsr" runat="server"  Text='<%# Eval("id") %>'></asp:Label>                                               
                                                </td>
                                                 <td class="singleCheckbox" style="text-align: center">
                                                     <asp:Label ID="Label1" runat="server"  Text='<%# Eval("customerName") %>'></asp:Label>                                               
                                                </td>
                                                 <td class="singleCheckbox" style="text-align: center">
                                                     <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("id") %>' OnClick="lnkDelete_Click" OnClientClick="return confirm('Do you want to remove this Customer?');" ></asp:LinkButton>
                                                     </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                               
                            </table>
                        </div>
                         
                         
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- ./wrapper -->
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btn_pdfDownload" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="Template/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Template/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="Template/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="Template/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Template/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Template/dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(function () {
            $('#example1').DataTable()
            $('#example2').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })
    </script>

</asp:Content>


