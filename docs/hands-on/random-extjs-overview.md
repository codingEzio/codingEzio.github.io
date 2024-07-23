### Metadata

- Version 4.2
- Documentation [here](https://cdn.sencha.com/ext/gpl/4.2.1/docs/)

### Scenarios and Thoughts

> Create and configure the data source

```javascript
var store = Ext.create(
    'Ext.data.Store',
    {
        [ 'id', 'name' ],
        getWhatFromWhereInHow:
        {
            异步,
            'File/Func',
            { root: 'data' }    (里id/name)
        },
        autoReqAndLoadDataInTheVariable
    }
)
```

> Use existing component

```javascript
var win = Ext.create('userDefinedComponent', { tweaks })

win.loadData();    // <- Ext.apply(this, { k:v, I: impl })
win.show();            // <- extend: 'Ext.window.Window'

// 0. It is always listening to various events
// 1. You close the component
// 2. It calls .close (.window.Window -> .panel.Panel)
// 3. It fires up the 'close' event
// 4. It runs code you have defined
win.on('close', function() { .. });
```

> Toolbars

```javascript
// At the top, commonly for CRUD operations
tbar: [
    { xtype: 'button', text: 'Button 1' }
    { customButton }
]
var customButton = Ext.create(
    'Ext.button.Button',
    {
        按钮名                 // e.g. 导入
        按钮图标             // e.g. icon-export
        按下去做什么     // e.g. set var, call func
    }
)


// At the bottom, commonly used for paging
bbar: Ext.create(
    'Ext.PagingToolbar',
    {
        dataSource
        displayPagingInfo
    }
)
```

> Grand Layout

```json
{
    region: "center"    // ~= left
    region: "east"
    region: "north"
    flex: 1
}
```

> Components inside components

```javascript
var withShorthand = Ext.create('Ext.Container', {
        region: 'north',
        border: false,
        height: 36,
        items: [{
                xtype: 'form',
                layout: 'hbox',
                defaults: {    margin: 3 },
                items: [
                    { xtype: 'textfield', fieldLabel: 'Name' },
                    { xtype: 'button', text: 'Submit'
                }]
        }]
});

var withoutShorthand = Ext.create('Ext.Container', {
        region: 'north',
        border: false,
        height: 36,
        items: [
                Ext.create('Ext.form.Panel', {
                        layout: Ext.create('Ext.layout.container.HBox'),
                        defaults: {
                                margin: 3
                        },
                        items: [
                                Ext.create('Ext.form.field.Text', {
                                        fieldLabel: 'Name'
                                }),
                                Ext.create('Ext.button.Button', {
                                        text: 'Submit'
                                })
                        ]
                })
        ]
});
```

> Grid/Table with listener `selectionchange`

```javascript
// Table -> [[Supercharged]] -> Grid (fetch/sort/filter/..)

// Models like Ext.selection.xxModel
//    classes were imported via 'uses: []' by the Table
//    events fired by the xxModel will be relayed to the Table
//    implementation needed to handle the events in the listeners

var sampleGrid = Ext.create(
    'ZAN.BrandManagement.BrandGrid',
    {
        名称
        比例
        区域
        具栏

         listeners: {

            // selModel     Ext.selection.Model     .getCount, getStore
            // records        Ext.data.Model                [0].get('id')

            selectionchange: function (selModel, records) {

                if (!Ext.isEmpty(selectedRecord)) {

                    // Always an array even with one item
                    selectedRecord[0].get('Name');
                    selectedRecord[0].get('Id');

                }

         }
    }
);
```

> Methods seen from `Ext.form.Panel`

```javascript
// .up


// .down


// .setDisabled (universal)
```
