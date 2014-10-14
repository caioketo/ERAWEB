function deleteClick(id) {
    if (confirm("Você tem certeza que quer apagar este Registro? Tudo referente a ele será excluído!")) {
        $.ajax({
            type: "POST",
            url: window.location.pathname + "/Delete?id=" + id,
            success: function (data) {
                location.reload();
            }
        });
    }
};