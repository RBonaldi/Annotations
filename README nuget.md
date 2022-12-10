Validate system exceptions. Specifically handle the generated exceptions.

# Validate

```cs
using ExceptionsLibrary;

public class ClassCoreException : CoreException<ClassCoreError>
{
        public ClassCoreException(
            ClassCoreError classCoreError)
        {
            AddError(classCoreError);
        }

        protected ClassCoreException(SerializationInfo info, 
            StreamingContext context) 
            : base(info, context)
        {
        }

        public override string Key => "ClassCoreException";
    }

    public class ClassCoreError : CoreError
    {
        public static ClassCoreError ErrorVariable =>
            new ClassCoreError("Description error.");
        
        protected ClassCoreError(string key, string message) 
            : base(key, message)
        {
        }
    }
}

```