var app = new Vue({
    el: '#app',
    data: {
        OrderDetail: {
            CreateDate: "",
            CreateDateStr: "",
            CustomerName: "",
            Id: -1,
            MemberName: "",
            OrdersId: -1,
            Price: -1,
            ProductName: "",
            Remark:"",
        }
    },
    methods: {
        GetOrderDetail(Id) {
            that = this;
            $.ajax({
                type: 'get',
                url: '/Home/OrderDetail/',
                data: {
                    'OrderId': Id
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    that.OrderDetail = result;
                    $('#detail').modal('show');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    debugger;
                    swal(jqXHR.responseText, '', 'error')
                }
            })
        },
        UpdateOrder(id) {
            that = this;
            $.ajax({
                type: 'put',
                url: '/Home/UpdateOrder/',
                data: {
                    'Order': that.OrderDetail
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                success: function (result) {
                    window.location.href = '/Home/OrderList/'
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    debugger;
                    swal(jqXHR.responseText, '', 'error')
                }
            })
        }
    },
    mounted() {
    }
})