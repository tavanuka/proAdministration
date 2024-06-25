Ext.define('proAdministration.Client.view.customers.CustomersView', {
    extend: 'Ext.grid.Grid',
    xtype: 'customersview',
    cls: 'customersview',
    controller: { type: 'customersviewcontroller' },
    // viewModel: { type: 'customersviewmodel' },
    store: { type: 'customersviewstore' },
    requires: [
        'Ext.Dialog',
        'Ext.form.Panel'
    ],

    dialog: {
        xtype: 'dialog',
        title: 'Dialog',

        closable: true,
        defaultFocus: 'textfield',
        maskTapHandler: 'onCancel',

        bodyPadding: 0,
        layout: 'fit',
        maxWidth: 550,

        items: [{
            xtype: 'formpanel',
            reference: 'form',
            autoSize: true,
            items: [{
                xtype: 'textfield',
                label: 'Name',
                required: true,
                bind: '{name}',
                allowBlank: false
            }, {
                xtype: 'emailfield',
                name: 'email',
                label: 'Email',
                bind: '{email}',
                allowBlank: false,
                required: true,
                validators: 'email'
            }]
        }],

        // We are using standard buttons on the button
        // toolbar, so their text and order are consistent.
        buttons: {
            ok: 'onOk',
            cancel: 'onCancel'
        }
    },

    columns: [
        { text: 'Name', dataIndex: 'name', flex: 1 },
        { text: 'Email', dataIndex: 'email', flex: 1 },
        { text: 'Phone', dataIndex: 'phoneNumber', flex: 1 },
        { text: 'Currency', dataIndex: 'currency', flex: 1 },
        { text: 'Address', dataIndex: 'address', flex: 1 },
        { text: 'Country', dataIndex: 'country', flex: 1 },
        {
            width: 50,
            hideable: false,

            cell: {
                tools: {
                    approve: {
                        iconCls: 'x-fa fa-check green',
                        handler: 'showDialog'
                    }
                }
            }
        }
    ]
});
