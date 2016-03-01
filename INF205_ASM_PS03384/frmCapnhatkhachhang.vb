Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmcapnhatkhachhang

    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=INF205PS03384.mssql.somee.com;packet size=4096;user id=PS03384;pwd=Manhmeo21296;data source=INF205PS03384.mssql.somee.com;persist security info=False;initial catalog=INF205PS03384"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "insert into KH_PS03384 values(@MAKH,@TENKH,@DIACHI,@Dienthoai)"
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMaKH.Focus()
            If txtMaKH.Text = "" Then
                MessageBox.Show("Bạn chưa nhập Mã Khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMaKH.Focus()
                If txtTenkh.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtdc.Focus()
                    If txtSDT.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập số điện thoại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        save.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                        save.Parameters.AddWithValue("@TENKH", txtTenkh.Text)
                        save.Parameters.AddWithValue("@DIACHI", txtdc.Text)
                        save.Parameters.AddWithValue("@DienThoai", txtSDT.Text)
                        save.ExecuteNonQuery()
                        MessageBox.Show("Lưu thành công")



                    End If
                End If
            End If

        Catch ex As Exception  'Ngược lại báo lỗi
            MessageBox.Show("Không được trùng mã khách hàng", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Dim hienthi As New Class1
        dgvKH.DataSource = hienthi.Loadkhachang.Tables(0)


    End Sub

    Private Sub btnxem_Click(sender As Object, e As EventArgs) Handles btnxem.Click
        Dim hienthi As New Class1
        dgvKH.DataSource = hienthi.Loadkhachang.Tables(0)
    End Sub

    Private Sub btnCapnhat_Click(sender As Object, e As EventArgs) Handles btnCapnhat.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update KH_PS03384 set MAKH=@MAKH, TENKH=@TENKH, DIACHI=@DIACHI, Dienthoai=@Dienthoai where MAKH=@MAKH"
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMaKH.Focus()
            If txtMaKH.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMaKH.Focus()
                If txtTenkh.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTenkh.Focus()
                    If txtdc.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtdc.Focus()
                        If txtSDT.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số điện thoại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else


                            addupdate.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                            addupdate.Parameters.AddWithValue("@TENKH", txtTenkh.Text)
                            addupdate.Parameters.AddWithValue("@DIACHI", txtdc.Text)
                            addupdate.Parameters.AddWithValue("@Dienthoai", txtSDT.Text)
                            addupdate.ExecuteNonQuery()
                            conn.Close() 'đóng kết nối
                            MessageBox.Show("Cập nhật thành công")
                            txtMaKH.Text = Nothing
                            txtTenkh.Text = Nothing
                            txtdc.Text = Nothing
                            txtSDT.Text = Nothing

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Dim hienthi As New Class1
        dgvKH.DataSource = hienthi.Loadkhachang.Tables(0)



    End Sub

    Private Sub dgvKH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKH.CellContentClick
        Dim click As Integer = dgvKH.CurrentCell.RowIndex
        txtMaKH.Text = dgvKH.Item(0, click).Value
        txtTenkh.Text = dgvKH.Item(1, click).Value
        txtdc.Text = dgvKH.Item(2, click).Value
        txtSDT.Text = dgvKH.Item(3, click).Value
    End Sub

    Private Sub btnXoa_Click_1(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from KH_PS03384 where MAKH=@MAKH"
        Dim delete As SqlCommand = New SqlCommand(delquery, conn)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        conn.Open()
        Try
            If txtMaKH.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                txtMaKH.Focus()
            Else
                If resulft = Windows.Forms.DialogResult.Yes Then
                    delete.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                    delete.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Xóa thành công")
                    
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Nhập đúng mã khách hàng cần xóa", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Dim hienthi As New Class1
        dgvKH.DataSource = hienthi.Loadkhachang.Tables(0)
    End Sub

    
End Class



