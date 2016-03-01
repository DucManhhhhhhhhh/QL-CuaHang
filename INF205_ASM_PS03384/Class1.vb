Imports System.Data.SqlClient
Imports System.Data
Public Class Class1
    Public Function Loadkhachang() As DataSet
        Dim chuoiketnoi As String = "workstation id=INF205PS03384.mssql.somee.com;packet size=4096;user id=PS03384;pwd=Manhmeo21296;data source=INF205PS03384.mssql.somee.com;persist security info=False;initial catalog=INF205PS03384"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadKH As New SqlDataAdapter("select MaKH as 'Mã KH' ,TENKH as 'Tên Khách Hàng', DIACHI as 'Địa chỉ', DienThoai as 'SĐT' from KH_PS03384", conn)
        Dim db As New DataSet
        conn.Open()
        LoadKH.Fill(db)
        conn.Close()
        Return db
    End Function

    ''
    Public Function Loadsanpham() As DataSet
        Dim chuoiketnoi As String = "workstation id=INF205PS03384.mssql.somee.com;packet size=4096;user id=PS03384;pwd=Manhmeo21296;data source=INF205PS03384.mssql.somee.com;persist security info=False;initial catalog=INF205PS03384"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadSP As New SqlDataAdapter("select MaSP as 'Mã Sản phẩm' ,TENSP as 'Tên Sản Phẩm', NGAYSX as 'Ngày Sản Xuất', GIA as ' Giá' from SP_PS03384", conn)
        Dim db As New DataSet
        conn.Open()
        LoadSP.Fill(db)
        conn.Close()
        Return db
    End Function

    
End Class
