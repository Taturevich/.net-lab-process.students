# Task workflow
* Create branch `task-#` (where "#" symbol is the number of the task e.g. task-1) from `develop` branch;
```

           | 
           |
          / task-#
         /
        |
        |
        |
develop |

```
* Commit and Push changes to this branch at least twice a week;
* Every commit has to have adequate description (Examples: "Implement repositry for Event", "Fix unit tests");
* After work on your task is done, merge branch `task-#` back to `develop` and add tag `task-#` to `develop` branch. Then delete `task-#` branch;

```
        |
        |[task-#]
         \
          \
           |       
           | 
           |
          / task-#
         /
        |
        |
        |
develop |

```

* Open PR to `master` branch using [pull_request_template](pull_request_template.md);
* Go to [training portal](https://www.training.by/) and send your task for review.
> Just paste a link to your pull request into description for the task.
* Fix ongoing issues that your reviewer opened by commiting fixes to `develop` branch;

# Issue workflow
* All issues should be resolved before PR to `master` opened;
* Don't close issues. This will be done by reviwer after he will ensure that issue was resolved; 

