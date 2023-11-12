# Obiquotus Language

## Available Resource

It is a resource included in the rented office

### Name proposal

In the spirit of Domain-Driven Design (DDD), it’s highly encouraged to use language that is specific and meaningful within the domain. Terms such as “AvailableResources”, “data”, “object”, “component”, or “part” might be too general in this context (for example part would be perfect in a factory context). So this could lead to potential misunderstandings. Therefore, opting for more precise, domain-specific terminology can greatly enhance clarity and communication.

Therefore, we propose to replace “Available Resources” with more specific terms that accurately represent the items and facilities in an office. For example, “Equipments” or “Facilities” are terms that are more specific yet still understandable to all stakeholders. These terms are not only more descriptive but also carry a positive connotation, which can have a beneficial marketing effect.

By using such specific terms, we ensure that the language is ubiquitous, reducing the cognitive load for all stakeholders and improving communication. This change aligns with the principles of DDD, enhancing our model’s expressiveness and making our software design more closely match the business domain.

Remember, the goal is to create a model that is a software reflection of the actual domain, and using the right language is a crucial part of this process. We believe that this change will be a great achievement in making our model more domain-centric and user-friendly.

Here is a list of possible terms ranked according to their relevance and common usage in the office context

1. **Equipments**: `The equipments in our office are up-to-date and efficient.`
2. **Facilities**: `I prefer the office number 9 because it has better facilities.`
3. **Amenities**: `The amenities in our office create a comfortable working environment.`
4. **Supplies**: `Our office is always stocked with necessary supplies.`
5. **Apparatus**: `The apparatus in our office are maintained regularly for smooth operation.`
6. **Implements**: `The office implements are designed for ease of use.`
7. **Instruments**: `The office instruments are calibrated for precision.`
8. **Utilities**: `The utilities in our office are reliable and efficient.`
9. **Materiel**: `The office materiel are organized for easy access.`
10. **Outfit**: `The office outfit is professional and functional.`
11. **Kit**: `Each office comes with a complete kit for meetings.`
12. **Gear**: `The office gear is perfect for presentations and meetings.`
13. **Accoutrements**: `The office accoutrements add a touch of sophistication.`
14. **Furnishings**: `The office furnishings are both practical and comfortable.`
15. **Appliances**: `The office appliances are high-quality and reliable.`
16. **Hardware**: `The office hardware is up-to-date and reliable.`
17. **Fixtures**: `The office fixtures are designed for productivity.`
18. **Installations**: `The office installations are well-suited for collaborative work.`
19. **Provisions**: `The office provisions are always replenished on time.`

### Conclusion

The terminology selected to replace Office.AvailableResources is

    Office.Facility

Plural term (for lack of other convention): this means "a collection of Facility items"

    Office.Facilities

Note: If the convention , or the configuration of the code automatically generates plurals adding `S` (i.e singular Person, plural Persons instead of singular Person, plural People) then the term Office.Facilitys will be used in the code meaning: a collection of Facility items.
