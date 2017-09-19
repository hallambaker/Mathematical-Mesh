~~~~
<?xml version="1.0" encoding="utf-8"?>
<xs:schema id="SRML"
    targetNamespace="http://hallambaker.com/Schemas/srml.xsd"
    elementFormDefault="qualified"
    xmlns="http://hallambaker.com/Schemas/srml.xsd"
    xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="srml" type="SrmlType"/>

  <xs:complexType name="SrmlType">
    <xs:sequence>
      <xs:element name="h1" type="xs:string" 
                    minOccurs="1" maxOccurs="1"/>
      <xs:element name="p" type="xs:string" />
      <xs:element name="button" type="ButtonType" 
                    minOccurs="1" maxOccurs="unbounded"/>      
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name="ButtonType">
    <xs:simpleContent>
      <xs:extension base="xs:string">
        <xs:attribute name="value" type="xs:string" />
      </xs:extension>
    </xs:simpleContent>
  </xs:complexType> 

</xs:schema>
~~~~