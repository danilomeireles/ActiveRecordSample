# Castle Active Record Sample

<p>
This sample project demonstrates how to use the Castle Active Record as an ORM option to generate the database tables automatically from entity classes, and perform CRUD operations. I created a very simple diagram class with only five classes that represent a part of an online store scenario.
</p>

<p>
In this example, I am using a GenericDao class that works with all kind of entities. Note that you will no longer need to create a DAO class for each entity in the project. 
</p>


## Class Diagram:

![alt tag](https://github.com/danilomeireles/CastleActiveRecordSample/blob/master/CastleActiveRecord/sample_images/class-diagram.jpeg)

## The Product Class:
<p>Note that the mapping is done directly in the class, rather than using XML files, as is done when using NHibernate directly.</p>

![alt tag](https://github.com/danilomeireles/CastleActiveRecordSample/blob/master/CastleActiveRecord/sample_images/product_class.jpeg)

## Creating a Customer:

![alt tag](https://github.com/danilomeireles/CastleActiveRecordSample/blob/master/CastleActiveRecord/sample_images/save_customer.jpeg)

## Creating Some Products:

![alt tag](https://github.com/danilomeireles/CastleActiveRecordSample/blob/master/CastleActiveRecord/sample_images/save_product.jpeg)
