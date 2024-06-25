Ext.define('proAdministration.Client.view.customers.CustomersViewStore', {
    extend: 'Ext.data.Store',
    alias: 'store.customersviewstore',
    model: 'proAdministration.Client.model.Customer',
    autoLoad: true,
    // fields: [
    //     {name: 'id'},
    //     {name: 'customerId'},
    //     {name: 'name'},
    //     {name: 'email'},
    //     {name: 'phoneNumber'},
    //     {name: 'currency'},
    //     {name: 'address'},
    //     {name: 'state'},
    //     {name: 'country'}
    // ],
    proxy: {
        type: 'ajax',
        reader: {
            type: 'json',
            rootProperty: 'items'
        },
        url: 'http://localhost:8080/api/customers'
    }
});
