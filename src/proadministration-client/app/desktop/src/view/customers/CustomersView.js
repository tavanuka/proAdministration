Ext.define('proAdministration.Client.view.customers.CustomersView', {
    extend: 'Ext.grid.Grid',
    xtype: 'customersview',
    cls: 'customersview',
    // controller: { type: 'customersviewcontroller' },
    // viewModel: { type: 'customersviewmodel' },
    store: { type: 'customersviewstore' },

    columns: [
        { text: 'Name', dataIndex: 'name', flex: 1 },
        { text: 'Email', dataIndex: 'email', flex: 1 },
        { text: 'Phone', dataIndex: 'phoneNumber', flex: 1 }
    ]
});
