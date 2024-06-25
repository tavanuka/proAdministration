Ext.define('proAdministration.Client.model.Customer', {
    extend: 'proAdministration.Client.model.Base',
    fields: [
        {name: 'id', type: 'int'},
        {name: 'customerId', type: 'string'},
        {name: 'name', type: 'string'},
        {name: 'email', type: 'string'},
        {name: 'phoneNumber', type: 'string'},
        {name: 'currency', type: 'string'},
        {name: 'address', type: 'string'},
        {name: 'state', type: 'string'},
        {name: 'country', type: 'string'}
    ]
});