Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmdanhsachsanpham

    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=INF205PS03384.mssql.somee.com;packet size=4096;user id=PS03384;pwd=Manhmeo21296;data source=INF205PS03384.mssql.somee.com;persist security info=False;initial catalog=INF205PS03384"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)

    Private Sub dgvSanpham_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSanpham.CellContentClick
        Dim click As Integer = dgvSanpham.CurrentCell.RowIndex
        txtMASP.Text = dgvSanpham.Item(0, click).Value
        txtTENSP.Text = dgvSanpham.Item(1, click).Value
        txtNgaySX.Text = dgvSanpham.Item(2, click).Value
        txtgia.Text = dgvSanpham.Item(3, click).Value
    End Sub

    Private Sub btnxem_Click(sender As Object, e As EventArgs) Handles btnxem.Click
        Dim hienthi As New Class1
        dgvSanpham.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    
    
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "insert into SP_PS03384 values(@MASP,@TENSP,@NGAYSX,@Gia) "
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtNgaySX.Focus()
                    If txtNgaySX.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập Ngày Sản xuất", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtgia.Focus()
                        If txtgia.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập Giá", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

                        Else
                            save.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            save.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            save.Parameters.AddWithValue("@NGAYSX", txtNgaySX.Text)
                            save.Parameters.AddWithValue("@Gia", txtgia.Text)
                            save.ExecuteNonQuery()
                            MessageBox.Show("Lưu thành công")


                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Không được trùng ", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Dim hienthi As New Class1
        dgvSanpham.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    Private Sub btnCapnhat_Click(sender As Object, e As EventArgs) Handles btnCapnhat.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update SP_PS03384 set MASP=@MASP, TENSP=@TENSP, NGAYSX=@NGAYSX, Gia=@Gia where MASP=@MASP "
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENSP.Focus()
                    If txtNgaySX.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập Ngày Sản Xuất", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtNgaySX.Focus()
                        If txtgia.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số lượng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else

                            addupdate.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            addupdate.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            addupdate.Parameters.AddWithValue("@Ngaysx", txtNgaySX.Text)
                            addupdate.Parameters.AddWithValue("@Gia", txtgia.Text)
                            addupdate.ExecuteNonQuery()
                            conn.Close()
                            MessageBox.Show("Cập nhật thành công")
                            txtMASP.Text = Nothing
                            txtTENSP.Text = Nothing
                            txtNgaySX.Text = Nothing
                            txtgia.Text = Nothing
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Dim hienthi As New Class1
        dgvSanpham.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from SP_PS03384 where MASP=@MASP"
        Dim delete As SqlCommand = New SqlCommand(delquery, conn)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        conn.Open()
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                txtMASP.Focus()
            Else
                If resulft = Windows.Forms.DialogResult.Yes Then
                    delete.Parameters.AddWithValue("@MASP", txtMASP.Text)
                    delete.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Xóa thành công")

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Nhập đúng mã sản phẩm cần xóa", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)

        End Try

        Dim hienthi As New Class1
        dgvSanpham.DataSource = hienthi.Loadsanpham.Tables(0)

        
    End Sub


End Class

