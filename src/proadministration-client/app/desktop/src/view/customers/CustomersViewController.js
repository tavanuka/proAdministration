Ext.define('proAdministration.Client.view.customersCustomersViewController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.customersviewcontroller',

    destroy: function () {
        Ext.destroy(this.dialog);

        this.callParent();
    },

    hideDialog: function () {
        var dialog = this.dialog;

        if (dialog) {
            dialog.hide();
        }
    },

    showDialog: function () {
        var dialog = this.dialog,
            view;

        if (!dialog) {
            view = this.getView();
            dialog = Ext.apply({
                hideMode: 'offsets',
                ownerCmp: view
            }, view.dialog);

            this.dialog = dialog = Ext.create(dialog);
        }

        dialog.show();
    },

    onCancel: function () {
        this.hideDialog();
    },

    onOk: function () {
        var form = this.lookup('form');

        if (form.validate()) {
            // In a real application, this would submit the form to the configured url
            // form.submit();
            this.hideDialog();

            Ext.Msg.alert(
                'Thank you!',
                'Your inquiry has been sent. We will respond as soon as possible.'
            );
        }
    }
});
