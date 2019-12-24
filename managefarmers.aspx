<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="managefarmers.aspx.cs" Inherits="managefarmers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <!-- /.box-header -->
                        <div class="box-body">
                            <br />

                            <div style="text-align: right;">
                                <asp:Button ID="btnNewFarmer" runat="server" Text="New Farmer" class="btn btn-Normal btn-primary" OnClick="btnNewFarmer_Click" Width="150" />
                            </div>
                            <br />
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <%--//id, name, img, address, mobileno, mobile2, password, milkrate, emailid, bankname, accountno, ifsc, deviceid, countryid, stateid, cityid, isdeleted, isactive--%>


                                        <th style="text-align: center">Name</th>
                                        <th style="text-align: center">Mobile No</th>
                                        <th style="text-align: center">Password</th>
                                        <th style="text-align: center">Milk Rate</th>
                                        <%--<th style="text-align: center">Image</th>
                                        <th style="text-align: center">Is Show</th>--%>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="repCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:Label>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobileno") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblpassword" runat="server" Text='<%# Eval("fpassword") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblmilkrate" runat="server" Text='<%# Eval("milkrate") %>'></asp:Label>
                                                </td>
                                                <%--<td style="text-align: center">
                                                    <asp:Image ID="imgfarmer" Width="75px" Height="50px" runat="server"></asp:Image>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:CheckBox ID="IsActive" runat="server" AutoPostBack="true" Checked='<%# Eval("isactive") %>' OnCheckedChanged="IsActive_CheckedChanged" />
                                                </td>--%>
                                                <td style="text-align: center">
                                                    <asp:HyperLink ID="hlEdit" runat="server" class="btn btn-success" Text="EDIT"></asp:HyperLink>&nbsp;
                                        &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="DELETE" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this record?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Name</th>
                                        <th style="text-align: center">Mobile No</th>
                                        <th style="text-align: center">Password</th>
                                        <th style="text-align: center">Milk Rate</th>
                                        <%--<th style="text-align: center">Image</th>
                                        <th style="text-align: center">Is Show</th>--%>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- ./wrapper -->
        </ContentTemplate>
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

